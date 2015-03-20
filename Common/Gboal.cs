using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Common
{
    public class Gboal
    {
        public static string Joke()
        {
            WebClient wc = new WebClient();
            Stream sm = wc.OpenRead("http://api.laifudao.com/open/xiaohua.json");
            StreamReader sr = new StreamReader(sm);
            return sr.ReadToEnd();
        }
    }
}
