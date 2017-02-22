using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public class JSONHelper
    {
        public static bool IsValidJsonString(string jsonString)
        {
            try
            {
                JToken token = JObject.Parse(jsonString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
