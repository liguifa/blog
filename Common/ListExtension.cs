using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ListExtension
    {
        public static string ToJson(this List<Common.Models.Article> list)
        {
            int i = 0;
            string result = "{\"data\":[";
            foreach (var item in list)
            {
                result += ("{\"title" + "\":\"" + item.Article_Title + "\",\"url\":\"" + item.Article_Url + "\",\"time\":\"" + item.Article_Time + "\",\"type\":\""+item.Article_Type+"\"},");

                i++;
            }
            if (i != 0)
            {
                result = result.Substring(0, result.Length - 1);
            }
            result += "],";
            result += ("\"count\":\"" + i + "\"");
            result += "}";
            return result;
        }
    }
}