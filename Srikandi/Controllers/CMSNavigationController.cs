using Srikandi.Helper;
using Srikandi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.DataAccess;

namespace Srikandi.Controllers
{
    public partial class CMSNavigationController : BaseController
    {

        private IGridMvcHelper gridMvcHelper;
        //
        // GET: /CMSNavigation/
        [BreadCrumb(Clear = true, Label = "Navigation")]
        [UserActionFilter(Action = ActionCode.GuidTypes.View)]
        public virtual ActionResult Index(string status)
        {

            switch (status)
            {
                case "Create_Success":
                    ViewBag.Success = "Item successfully created";
                    break;
                case "Edit_Success":
                    ViewBag.Success = "Item successfully updated";
                    break;
                case "Delete_Success":
                    ViewBag.Success = "Item successfully deleted";
                    break;
                default:
                    ViewBag.Success = status;
                    break;
            }

            return View();
        }

        [BreadCrumb(Label = "Add Navigation")]
        [UserActionFilter(Action = ActionCode.GuidTypes.Insert)]
        public virtual ActionResult Add()
        {
            NavigationModel model = new NavigationModel();
            GetListNavigationParent();
            GetListPrevilege();
            return View(model);
        }

        [HttpPost]
        [UserActionFilter(Action = ActionCode.GuidTypes.Insert)]
        public virtual ActionResult Add(NavigationModel model)
        {
            CMSUserInformation _CMSInformation = new CMSUserInformation();
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (string.IsNullOrEmpty(model.Controller))
            {
                ModelState.AddModelError("Controller", "Controller name is required");
            }
            if (model.sort < 0)
            {
                ModelState.AddModelError("sort", "Sort can not be null or smaller than 0");
            }
            if (ModelState.IsValid)
            {
                CMSNavigation navigation = NavigationModelToCMSNavigation(model);

                var result = CMSNavigation.Insert(navigation, CurrentUser.FullName);
                if (result.IsSuccess)
                {
                    //set navigation previlage
                    NavigationAddPrevilage(model.Previlage, navigation.ID);

                    SetRemoveCurrentNavigationCache();
                    _CMSInformation.SetRemoveCurrentAllowedControllerActionCache();
                    return RedirectToAction(MVC.CMSNavigation.Index("Create_Success"));
                }
                else
                    ModelState.AddModelError(result.MessageText, result.MessageText);
            }
            GetListNavigationParent();
            GetListPrevilege();
            return View();
        }

        [BreadCrumb(Label = "Edit Navigation")]
        [UserActionFilter(Action = ActionCode.GuidTypes.Update)]
        public virtual ActionResult Edit(long NavId)
        {
            CMSNavigation currentNav = CMSNavigation.GetByID(NavId);
            if (currentNav == null)
            {
                return RedirectToAction(MVC.CMSNavigation.Index());
            }
            GetListNavigationParent();
            GetListPrevilege();
            ViewBag.currentNavPrevilage = CMSNavigationPrivilegeMapping.GetByNavigation(currentNav.ID).ToList();
            NavigationModel model = CMSNavigationToNavigationModel(currentNav);
            return View(model);
        }

        [HttpPost]
        [UserActionFilter(Action = ActionCode.GuidTypes.Update)]
        public virtual ActionResult Edit(NavigationModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (string.IsNullOrEmpty(model.Controller))
            {
                ModelState.AddModelError("Controller", "Controller name is required");
            }
            if (model.sort < 0)
            {
                ModelState.AddModelError("sort", "Sort can not be null or smaller than 0");
            }
            CMSUserInformation _CMSInformation = new CMSUserInformation();
            if (ModelState.IsValid)
            {
                CMSNavigation navigation = CMSNavigation.GetByID(model.ID);
                navigation.Name = model.Name;
                navigation.Controller = model.Controller;
                navigation.sort = model.sort;
                navigation.IsChild = (model.ParentID != null);
                navigation.ParentID = model.ParentID;
                navigation.IsHide = model.IsHide;
                var result = CMSNavigation.Update(navigation, CurrentUser.FullName);
                if (result.IsSuccess)
                {
                    NavigationEditPrevilage(model.Previlage, navigation.ID);
                    SetRemoveCurrentNavigationCache();
                    _CMSInformation.SetRemoveCurrentAllowedControllerActionCache();
                    return RedirectToAction(MVC.CMSNavigation.Index("Edit_Success"));
                }
                else
                    ModelState.AddModelError(result.MessageText, result.MessageText);
            }
            GetListNavigationParent();
            GetListPrevilege();
            return View();
        }

        private void GetListNavigationParent()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            IQueryable<CMSNavigation> listdata = CMSNavigation.GetAllParent();
            foreach (CMSNavigation data in listdata)
            {

                items.Add(new SelectListItem { Text = data.Name, Value = data.ID.ToString(), Selected = false });
            }
            ViewBag.ListNavigationParent = items;
        }

        [HttpGet]
        [UserActionFilter(Action = ActionCode.GuidTypes.Delete)]
        public virtual ActionResult Delete(long ID)
        {
            CMSNavigation navigation = CMSNavigation.GetByID(ID);
            CMSNavigationPrivilegeMapping.HardDeleteByNavigationID(ID);
            CMSNavigation.Delete(navigation);
            return RedirectToAction(MVC.CMSNavigation.Index("Delete_Success"));
        }

        private CMSNavigation NavigationModelToCMSNavigation(NavigationModel model)
        {
            CMSNavigation navigation = new CMSNavigation();
            navigation.Name = model.Name;
            navigation.Controller = model.Controller;
            navigation.sort = model.sort;
            navigation.IsChild = (model.ParentID != null);
            navigation.ParentID = model.ParentID;
            navigation.IsHide = model.IsHide;
            return navigation;
        }

        private void NavigationAddPrevilage(long[] Previlage, long NavigationID)
        {
            if (Previlage != null)
            {
                foreach (long _Previlage in Previlage)
                {
                    CMSNavigationPrivilegeMapping _CMSNavigationPrivilegeMapping = new CMSNavigationPrivilegeMapping();
                    _CMSNavigationPrivilegeMapping.CMSNavigationID = NavigationID;
                    _CMSNavigationPrivilegeMapping.CMSPrivilegeID = _Previlage;
                    CMSNavigationPrivilegeMapping.Insert(_CMSNavigationPrivilegeMapping, CurrentUser.FullName);
                }
            }
        }

        private void NavigationEditPrevilage(long[] Previlage, long NavigationID)
        {
            List<CMSNavigationPrivilegeMapping> NavigationPrevilages = CMSNavigationPrivilegeMapping.GetByNavigation(NavigationID).ToList();

            if (Previlage != null && Previlage.Count() > 0)
            {
                foreach (var item in Previlage)
                {
                    CMSNavigationPrivilegeMapping mapping = CMSNavigationPrivilegeMapping.GetByNavigationAndPrevilage(NavigationID, item);
                    if (mapping != null)
                    {
                        mapping.IsActive = true;
                        CMSNavigationPrivilegeMapping.Update(mapping, CurrentUser.FullName);
                    }
                    else
                    {
                        mapping = new CMSNavigationPrivilegeMapping
                        {
                            CMSNavigationID = NavigationID,
                            CMSPrivilegeID = item,
                            IsActive = true
                        };
                    }
                    CMSNavigationPrivilegeMapping.Insert(mapping, CurrentUser.FullName);
                }
            }
            else
            {
                List<CMSNavigationPrivilegeMapping> mappings = CMSNavigationPrivilegeMapping.GetByNavigation(NavigationID).Where(x => x.IsActive && !x.IsDeleted).ToList();
                foreach (var mapping in mappings)
                {
                    mapping.IsActive = false;
                    CMSNavigationPrivilegeMapping.Update(mapping, CurrentUser.FullName);
                }
            }
        }

        private NavigationModel CMSNavigationToNavigationModel(CMSNavigation model)
        {
            NavigationModel navigation = new NavigationModel();
            navigation.ID = model.ID;
            navigation.Name = model.Name;
            navigation.Controller = model.Controller;
            navigation.sort = model.sort;
            navigation.ParentID = model.ParentID;
            navigation.IsHide = model.IsHide;
            return navigation;
        }

        private void GetListPrevilege()
        {
            List<CMSPrivilege> _CMSPrevilege = CMSPrivilege.GetAll().ToList();
            ViewBag.CMSPrevilage = _CMSPrevilege;
        }

        #region List Navigation Grid
        [ChildActionOnly]
        public virtual ActionResult GridGetAllNavigation()
        {
            gridMvcHelper = new GridMvcHelper();
            IOrderedQueryable<CMSNavigation> allNavigation = CMSNavigation.GetAll().OrderBy(x => x.sort);
            AjaxGrid<CMSNavigation> grid = this.gridMvcHelper.GetAjaxGrid(allNavigation);
            return PartialView(grid);
        }

        [HttpGet]
        public virtual ActionResult GridGetAllNavigationPager(string txtSearch, int? page)
        {
            gridMvcHelper = new GridMvcHelper();
            IOrderedQueryable<CMSNavigation> allData = CMSNavigation.GetAll().OrderBy(x => x.sort);
            if (!string.IsNullOrEmpty(txtSearch))
            {
                allData = allData.Where(x => x.Name.Contains(txtSearch) || x.Controller.Contains(txtSearch)).OrderBy(x => x.sort);
            }
            AjaxGrid<CMSNavigation> grid = this.gridMvcHelper.GetAjaxGrid(allData, page);
            object jsonData = this.gridMvcHelper.GetGridJsonData(grid, MVC.CMSNavigation.Views.GridGetAllNavigation, this);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
