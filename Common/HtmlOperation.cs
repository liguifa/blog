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

        public void AddHtml(string url,string body,string title,string time)
        {
            body = "<div class='panel-bod'><h3>" + title + "</h3><span class='glyphicon glyphicon-user'></span><span>&nbsp;&nbsp;<a href='#'>Hello 发哥</a></span><span class='glyphicon glyphicon-time'></span><span>&nbsp;&nbsp;" + time + "</span><hr />" + body+"</div><div class='panel-footer'><img src='/Themes/Images/me.png'><div class='author'><div itemprop='name'>作者 : Hello 发哥</div><div itemprop='description'>任性 我想要的现在就要</div></div><div class='clear'></div></div>";
            FileStream fs = new FileStream(url, FileMode.CreateNew);
            byte[] b=Encoding.Default.GetBytes(body);
            fs.Write(b, 0, b.Length);
            fs.Close();
        }
    }
}
