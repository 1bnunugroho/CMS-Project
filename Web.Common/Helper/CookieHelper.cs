using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.Common.Helper
{
    public class CookieHelper
    {
        private static string COOKIE_PREFIX = ConfigurationManager.AppSettings["CookiePrefix"];
        private static string COOKIE_DOMAIN = ConfigurationManager.AppSettings["CookieDomain"];
        public const int CookieTimeoutInDays = 1;

        public static void Add(string key, string value, bool nonPersistent, bool encrypt = true)
        {
            if (encrypt)
            {
                value = Encrypt.EncryptString(value);
            }
            HttpCookie Cookie = new HttpCookie(COOKIE_PREFIX + key, value);
            Cookie.Domain = COOKIE_DOMAIN;

            if (!nonPersistent)
                Cookie.Expires = DateTime.Now.AddDays(CookieTimeoutInDays);

            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        public static void Remove(string key)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key];
            if (Cookie != null)
            {
                Cookie.Expires = DateTime.Now.AddDays(-99);
                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
        }

        public static string Get(string key, bool encrypted = true)
        {
            string cookieVal = String.Empty;
            if (HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key] != null)
            {
                cookieVal = HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key].Value;

                if (encrypted)
                    cookieVal = Encrypt.DecryptString(cookieVal);
            }
            return cookieVal;
        }

        public static bool CookieExist(string key)
        {

            // *** Check to see if we have a cookie we can use

            HttpCookie loCookie = HttpContext.Current.Request.Cookies[COOKIE_PREFIX + key];

            if (loCookie == null)
                return false;

            return true;
        }

        public static void RemoveAll()
        {
            HttpCookie aCookie;
            string cookieName;
            int limit = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = HttpContext.Current.Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-99);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
        }
    }
}