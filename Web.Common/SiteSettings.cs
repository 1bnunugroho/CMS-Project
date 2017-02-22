using System.Configuration;

namespace Web.Common
{
    public class SiteSettings
    {
        public static string SITE_URL = "SITE_URL";
        public static string API_URL = "API_URL";
        public static string ASSET_URL = "ASSET_URL";
        public static string DefaultControler = "DefaultControler";

        public static string reCaptchaPrivateKey
        {
            get
            {
                return ConfigurationManager.AppSettings["reCaptchaPrivateKey"];
            }
        }
        public static string ImgURL
        {
            get
            {
                return ConfigurationManager.AppSettings["ImgURL"];
            }
        }
        public static string SiteURL
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteURL"];
            }
        }
        public static string FacebookClientID
        {
            get
            {
                return ConfigurationManager.AppSettings["FacebookClientID"];
            }
        }

        public static int MinuteCache {
            get
            {
                int minute = 1;
                int.TryParse(ConfigurationManager.AppSettings["MinuteCache"], out minute);
                return minute;
            }
        }

    }
}
