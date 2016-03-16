using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AlphaRenting
{
    public class Tools
    {
        public static int ConvertIntFromString(string text)
        {
            if (Regex.IsMatch(text, @"^[a-zA-Z]+$"))
                return 0;
            else if (text.All(c => Char.IsDigit(c)))
            {
                return Convert.ToInt32(text);
            }
            else
                return 0;
        }
    }
}