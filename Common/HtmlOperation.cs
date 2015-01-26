using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    public class HtmlOperation
    {
        public string ReadHtml(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            Byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
