using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common.Helper;
using Web.DataAccess;
using Srikandi.Helper;

namespace Srikandi.Controllers
{
    public partial class BaseController : Controller
    {
        //
        // GET: /Base/
        public CMSUser CurrentUser
        {
            get
            {
                return CMSUserInformation.CurrentUser;
            }
        }

        public CMSRole CurrentRole
        {
            get
            {
                return CMSUserInformation.CurrentRole;
            }
        }

        public List<CMSNavigationPrivilegeMapping> CurrentNavigationPrivilegeMapping
        {
            get
            {
                return CMSUserInformation.CurrentNavigationPrivilegeMapping;
            }
        }
        public List<CMSNavigation> CurrentNavigation
        {
            get
            {
                return CMSUserInformation.CurrentNavigation;
            }
        }

        public List<CMSNavigation> SetCurrentNavigationCache()
        {
            List<CMSNavigation> navigations = new List<CMSNavigation>();
            string currNavigationKey = string.Format("{0}-{1}", CurrentRole.ID, CurrentRole.Name);
            List<CMSNavigation> cachedsharingskey = new Web.Common.Helper.InMemoryCache().GET<List<CMSNavigation>>(currNavigationKey);
            if (cachedsharingskey != null)
                navigations = cachedsharingskey;
            else
            {
                navigations = CurrentNavigation;
                new Web.Common.Helper.InMemoryCache().SET<dynamic>(currNavigationKey, () => navigations);
            }
            return navigations;
        }

        public void SetRemoveCurrentNavigationCache()
        {
            Web.Common.Helper.InMemoryCache cacheFunc = new Web.Common.Helper.InMemoryCache();
            string currNavigationKey = CurrentRole.Name + CurrentRole.ID;
            List<CMSNavigation> cachedsharingskey = cacheFunc.GET<List<CMSNavigation>>(currNavigationKey);
            if (cachedsharingskey != null)
                cacheFunc.REMOVE(currNavigationKey);
            SetCurrentNavigationCache();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (CookieHelper.CookieExist("Administrator_Username") == false)
                filterContext.Result = new RedirectResult(Url.Action(MVC.Account.Login()));
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public bool ValidateModel(object model, out List<string> result)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            List<ValidationResult> listValidationResult = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(model, context, listValidationResult, true);
            result = listValidationResult.Select(x => x.ErrorMessage).ToList();
            return isValid;
        }

    }
}
