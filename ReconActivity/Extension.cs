using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReconActivity
{
    public static class Extension
    {
        public static string GetString(this int? value)
        {
            return value !=  null ? value.ToString() : "-";
        }

        public static string GetString(this string value)
        {
            return string.IsNullOrEmpty(value) ? "-" :  value.ToString();
        }
    }
}
