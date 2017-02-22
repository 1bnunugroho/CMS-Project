using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public static class ContentHelper
    {
        /// <summary>
        /// Removes the special characters from a title string to create a page name.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            string output = Regex.Replace(str, @"[^\w\s]", " ", RegexOptions.Compiled);

            output = output.Trim();

            while (output.Contains("_"))
            {
                output = output.Replace("_", "-");
            }

            while (output.Contains("  "))
            {
                output = output.Replace("  ", "-");
            }
            output = output.Replace(" ", "-");
            while (output.Contains("--"))
            {
                output = output.Replace("--", "-");
            }
            output = output.Replace(" ", "");
            return output;
        }

        public static string RemoveSpecialCharactersLeaveHypen(string str)
        {
            string output = Regex.Replace(str, @"[^\w\s]", " ", RegexOptions.Compiled);

            output = output.Trim();

            while (output.Contains("  "))
            {
                output = output.Replace("  ", "-");
            }
            output = output.Replace(" ", "-");
            while (output.Contains("--"))
            {
                output = output.Replace("--", "-");
            }
            output = output.Replace(" ", "");
            return output;
        }

        /// <summary>
        /// Methods to remove HTML from strings.
        /// </summary>
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<[^>]*(>|$)", string.Empty);
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        /// <summary>
        /// Cut until space
        /// </summary>
        public static string CutUntilSpace(string source, int MinChar, int MaxChar, string Replacement)
        {
            string newString = "";
            if (!string.IsNullOrEmpty(source))
            {
                if (source.Length < MaxChar)
                    return source;
                newString = source.Substring(0, MaxChar);
                int spacePosition = newString.LastIndexOf(' ');
                if (spacePosition < MinChar)
                    return newString + Replacement;
                else
                    return newString.Substring(0, spacePosition).Trim() + Replacement;
            }
            else
                return source;
        }
    }
}

