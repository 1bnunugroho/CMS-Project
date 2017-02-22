using Srikandi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Common;
using Web.Common.Helper;
using Web.DataAccess;

namespace Srikandi.Helper
{
    public class CMSUserInformation
    {
        public static CMSUser CurrentUser
        {
            get
            {
                CMSUser user = null;
                if (CookieHelper.CookieExist("Administrator_Username") == false)
                    return user;
                else
                {
                    string userLoggedInString = CookieHelper.Get("Administrator_Username", true);
                    user = CMSUser.GetByUsername(userLoggedInString);
                    if (user == null)
                    {
                        return user;
                    }
                    return user;
                }
            }
        }

        public static CMSRole CurrentRole
        {
            get
            {
                return CurrentUser.CMSRole;
            }
        }

        public static List<CMSNavigationPrivilegeMapping> CurrentNavigationPrivilegeMapping
        {
            get
            {
                return CurrentRole.CMSRoleNavigationPrivilegeMappings.Where(x => !x.IsDeleted && x.IsActive)
                .Select(x => x.CMSNavigationPrivilegeMapping).Distinct().ToList();
            }
        }
        public static List<CMSNavigation> CurrentNavigation
        {
            get
            {
                return CurrentNavigationPrivilegeMapping.Select(x => x.CMSNavigation)
                    .Where(x => !x.IsDeleted).Distinct().OrderBy(x => x.sort).ToList();
            }
        }


        public static List<UserAccessModel> GetAllowedControllerAction
        {
            get
            {
                List<UserAccessModel> allowedControllerAction = new List<UserAccessModel>();
                List<CMSNavigationPrivilegeMapping> lstNavPriv = CurrentNavigationPrivilegeMapping;
                foreach (CMSNavigationPrivilegeMapping navpriv in lstNavPriv)
                {
                    UserAccessModel model = new UserAccessModel();
                    model.Controler = navpriv.CMSNavigation.Controller;
                    model.Action = navpriv.CMSPrivilege.Code;
                    allowedControllerAction.Add(model);
                }

                //defult controller
                string rawControler = SiteSettings.DefaultControler;
                List<string> listDefaultControler = new List<string>();
                if (!string.IsNullOrEmpty(rawControler))
                    listDefaultControler = rawControler.Split(new string[] { "," }, System.StringSplitOptions.None).ToList();

                foreach (string controller in listDefaultControler)
                {

                    UserAccessModel model = new UserAccessModel();
                    model.Controler = controller;
                    model.Action = Guid.NewGuid();
                    allowedControllerAction.Add(model);
                }
                return allowedControllerAction;
            }
        }


        public List<UserAccessModel> SetCurrentAllowedControllerActionCache()
        {
            List<UserAccessModel> AllowedControllerAction = new List<UserAccessModel>();
            string currNavigationKey = "_ALLOWEDCONTROLLER_" + CurrentRole.Name + CurrentRole.ID;
            List<UserAccessModel> cachedsharingskey = new Web.Common.Helper.InMemoryCache().GET<List<UserAccessModel>>(currNavigationKey);
            if (cachedsharingskey != null)
                AllowedControllerAction = cachedsharingskey;
            else
            {
                AllowedControllerAction = GetAllowedControllerAction;
                new Web.Common.Helper.InMemoryCache().SET<List<UserAccessModel>>(currNavigationKey, () => AllowedControllerAction);
            }
            return AllowedControllerAction;
        }

        public void SetRemoveCurrentAllowedControllerActionCache()
        {
            Web.Common.Helper.InMemoryCache cacheFunc = new Web.Common.Helper.InMemoryCache();
            string currNavigationKey = "_ALLOWEDCONTROLLER_" + CurrentRole.Name + CurrentRole.ID;
            List<CMSNavigation> cachedsharingskey = cacheFunc.GET<List<CMSNavigation>>(currNavigationKey);
            if (cachedsharingskey != null)
                cacheFunc.REMOVE(currNavigationKey);
            SetCurrentAllowedControllerActionCache();
        }
    }
}