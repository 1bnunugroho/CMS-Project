using Srikandi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Web.Common.Helper;
using Web.DataAccess;

namespace Srikandi.Controllers
{
    public partial class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public virtual ActionResult Login()
        {
            ViewBag.Title = "Login";
            if (CookieHelper.CookieExist("Administrator_Username") == true)
            {
                string userLoggedInString = CookieHelper.Get("Administrator_Username", true);
                CMSUser userLoggedIn = CMSUser.GetByUsername(userLoggedInString);
                if (userLoggedIn == null)
                {
                    return RedirectToAction(MVC.Account.Logout());
                }
                return Redirect(Url.Content("~"));
            }
            else
                return View();

        }


        [HttpPost]
        public virtual ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                string _UserName = model.Username;
                CMSUser predictedUser = CMSUser.GetByUsername(model.Username);
                if (predictedUser == null)
                {
                    ModelState.AddModelError("", "Invalid UserName or password");
                    return View();
                }
                string _Password = GetEncriptedPassword(model.Password, predictedUser.UserPrivateSecret);
                CMSUser _User = CMSUser.GetByUsernameAndPassword(_UserName, _Password);

                if (_User == null)
                {
                    ModelState.AddModelError("", "Invalid Email or password");
                    return View();
                }
                else
                {
                    CookieHelper.RemoveAll();
                    CookieHelper.Add("Administrator_Username", _User.Username, false, true);

                    return RedirectToAction(MVC.Home.Index());
                }
            }


            return View();
        }

        public virtual ActionResult Logout()
        {
            CMSUser _User = null;
            if (CookieHelper.CookieExist("Administrator_Username") == true)
            {
                string userLoggedInString = CookieHelper.Get("Administrator_Username", true);
                _User = CMSUser.GetByUsername(userLoggedInString);
            }

            CookieHelper.Remove("Administrator_Username");
            CookieHelper.RemoveAll();

            return RedirectToAction(MVC.Account.Login());
        }


        private string GetEncriptedPassword(string PlainPassword, Guid Salts)
        {
            string raw = PlainPassword + Salts;
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(PlainPassword + Salts.ToString());
            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}