using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public class PhoneHelper
    {
        public static bool isPhoneValid(string phoneNumber)
        {
            bool isValid = false;
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                Match match = Regex.Match(phoneNumber, @"08\d{9,11}$");
                if (match.Success)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

    }
}
