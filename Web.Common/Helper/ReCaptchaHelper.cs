﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Web.Common.Helper
{
    public class ReCaptchaHelper
    {
        public static string Validate(string EncodedResponse)
        {
            var client = new System.Net.WebClient();
            string PrivateKey = SiteSettings.reCaptchaPrivateKey;

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));
            var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaHelper>(GoogleReply);

            return captchaResponse.Success;
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}
