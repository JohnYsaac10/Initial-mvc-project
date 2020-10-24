using BlnckProyect.Infrastructure.JsonConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BlnckProyect.Infrastructure.Helpers
{
    public static class Extentions
    {
        public static string MaskEmail(this string correo)
        {
            if (string.IsNullOrEmpty(correo))
                return string.Empty;
            string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
            string result = Regex.Replace(correo, pattern, m => new string('*', m.Length));
            return result;
        }

        public static string MaskMobile(this string mobile)
        {
            int startIndex = 3; string mask = "****";
            if (string.IsNullOrEmpty(mobile))
                return string.Empty;

            string result = mobile;
            int starLengh = mask.Length;


            if (mobile.Length >= startIndex)
            {
                result = mobile.Insert(startIndex, mask);
                if (result.Length >= (startIndex + starLengh * 2))
                    result = result.Remove((startIndex + starLengh), starLengh);
                else
                    result = result.Remove((startIndex + starLengh), result.Length - (startIndex + starLengh));
            }

            return result;
        }
    
        public static ErrorMessage GetError(this ApplicationSettings settings, int statusCode)
        {
            return settings.ErrorMessages.FirstOrDefault(elem => elem.code == statusCode);
        }

    }
}