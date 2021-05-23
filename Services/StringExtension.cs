using System;
using System.Text;

namespace ClientsApi.Services
{
    public static class StringExtension
    {
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            var stringBuilder = new StringBuilder(str);
            stringBuilder[0] = char.ToUpper(stringBuilder[0]);
            return stringBuilder.ToString();
        }
    }
}