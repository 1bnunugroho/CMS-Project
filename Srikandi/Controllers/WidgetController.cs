using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.DataAccess;

namespace Srikandi.Controllers
{
    public partial class WidgetController : BaseController
    {
        // GET: Widget
        public virtual ActionResult TopNavigationBar()
        {
            ViewBag.CurrentUser = CurrentUser.FullName;
            return PartialView();
        }

        public virtual ActionResult Navigation()
        {
            List<CMSNavigation> navigations = new List<CMSNavigation>();
            navigations = SetCurrentNavigationCache();
            return PartialView(navigations);
        }

    }
}