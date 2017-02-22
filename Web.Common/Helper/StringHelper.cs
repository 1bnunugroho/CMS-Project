using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public class StringHelper
    {
        private static Random random = new Random();
        public static string GeneratedPassword()
        {
            string result = "";

            var ListLetter = new List<string>(new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            var ListNumber = new List<string>(new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" });

            string FirstLetter = GeneratedRandomFromList(ListLetter, 1);
            string NumberCharacter = GeneratedRandomFromList(ListNumber, 3);
            string LastLetter = GeneratedRandomFromList(ListLetter, 4, false);
            return string.Format("{0}{1}{2}", FirstLetter, NumberCharacter, LastLetter);
        }

        private static string GeneratedRandomFromList(List<string> listString, int length, bool IsUpperCase = true)
        {
            int myRandomIndex = 0;
            var myList = listString;
            var results = new List<string>();
            var r = new Random(DateTime.Now.Millisecond);
            for (int ii = 0; ii < length; ii++)
            {
                myRandomIndex = r.Next(myList.Count);
                results.Add(myList[myRandomIndex]);
                myList.RemoveAt(myRandomIndex);
            }

            return IsUpperCase ? string.Join("", results).ToUpper() : string.Join("", results).ToLower();


        }

        public static bool IsBase64String(string s)
        {
            s = s.Trim();
            int mod4 = s.Length % 4;
            if (mod4 != 0)
            {
                return false;
            }
            int i = 0;
            bool checkPadding = false;
            int paddingCount = 1;//only applies when the first is encountered.
            for (i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (checkPadding)
                {
                    if (c != '=')
                    {
                        return false;
                    }
                    paddingCount++;
                    if (paddingCount > 3)
                    {
                        return false;
                    }
                    continue;
                }
                if (c >= 'A' && c <= 'z' || c >= '0' && c <= '9')
                {
                    continue;
                }
                switch (c)
                {
                    case '+':
                    case '/':
                        continue;
                    case '=':
                        checkPadding = true;
                        continue;
                }
                return false;
            }
            //if here
            //, length was correct
            //, there were no invalid characters
            //, padding was correct
            return true;
        }

        public static bool IsLettersOnly(string s)
        {
            return Regex.IsMatch(s, @"^([^0-9!@#$%^&*]*)$");
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
