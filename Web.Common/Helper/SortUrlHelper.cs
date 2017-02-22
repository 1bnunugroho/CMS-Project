using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public class SortUrlHelper
    {
        public SortUrlHelper()
        {

        }

        public string TinyUrl(string longurl)
        {
            try
            {
                string googleApiKey = "AIzaSyCu5ZRZEhc2poAgjPJl8kKDO56R5bnIzAI";
                string _requestUrl = string.Format("https://www.googleapis.com/urlshortener/v1/url?key={0}", googleApiKey);
                using (WebClient client = new WebClient())
                {
                    paramShortenUrl param = new paramShortenUrl() { longUrl = longurl };
                    string jsonParam = JsonConvert.SerializeObject(param);

                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string responsString = client.UploadString(_requestUrl, jsonParam);
                    if (!string.IsNullOrEmpty(responsString))
                    {
                        var response = JsonConvert.DeserializeObject<responseShortenUrl>(responsString, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                        if (response != null && !string.IsNullOrEmpty(response.id))
                        {
                            //response.id = short url
                            return response.id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return longurl;
            }
            return longurl;
        }

        public class responseShortenUrl
        {
            public string kind { get; set; }
            public string id { get; set; }
            public string longUrl { get; set; }
        }
        public class paramShortenUrl
        {
            public string longUrl { get; set; }

        }
    }
}
