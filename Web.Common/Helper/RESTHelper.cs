using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web.Common.Helper
{
    public class RESTHelper
    {
        public static T Get<T>(string url, string token = "")
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token.Trim()))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage responseMessage = client.GetAsync(url).Result;
                return ResultHandler<T>(responseMessage);
            }
        }

        public static T Post<T>(string url, object param, string token = "")
        {
            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token.Trim()))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string postBody = JsonConvert.SerializeObject(param);
                HttpResponseMessage responseMessage = client.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).Result;

               
                return ResultHandler<T>(responseMessage);
            }
        }

        public static T ResultHandler<T>(HttpResponseMessage responseMessage)
        {
            string responseString = responseMessage.Content.ReadAsStringAsync().Result;
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                if (JSONHelper.IsValidJsonString(responseString))
                {
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
                else
                {
                    return default(T);
                }
            }
            else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpException((int)HttpStatusCode.Unauthorized, responseString);
            }
            else
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, responseString);
            }
        }
    }
}
