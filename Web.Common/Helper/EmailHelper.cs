using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public class EmailHelper
    {
        public static bool IsValidEmail(string email)
        {
            bool isValid = false;
            if (!string.IsNullOrWhiteSpace(email))
            {
                Match match = Regex.Match(email, "^([\\w-]+(?:\\.[\\w-]+)*)@((?:[\\w-]+\\.)*\\w[\\w-]{0,66})\\.([a-z]{2,6}(?:\\.[a-z]{2})?)$", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    isValid = true;
                }
            }

            return isValid;
        }


        public static bool IsValidEmailUmbraco(string email)
        {
            var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return !string.IsNullOrEmpty(email) && r.IsMatch(email);
        }
    }
}
