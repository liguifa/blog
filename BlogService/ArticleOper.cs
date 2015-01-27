using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService
{
    public class ArticleOper : BaseBLL<Common.Models.Article>
    {
        public List<Common.Models.Article> GetHotArticle(int type)
        {
            return base.Search(d => d.Article_IsDel == false && d.Article_Type == type, d => d.Article_Time, 1, 2);
        }

        public List<Common.Models.Article> GetPageArticle(string type, string pageIndex, string pageSize)
        {
            int index = 0;
            int size = 0;
            int TypeInt = 0;
            try { index = Convert.ToInt32(pageIndex); }
            catch { }
            try { size = Convert.ToInt32(pageSize); }
            catch { }
            switch (type)
            {
                case "Technology": TypeInt = 1; break;
                case "Edit": TypeInt = 2; break;
                case "Essay": TypeInt = 3; break;
            }
            return base.Search(d => d.Article_IsDel == false && d.Article_Type == TypeInt, d => d.Article_Time, index, size);
        }

        public long GetArticleCount(string type)
        {
            int TypeInt = 0;
            switch (type)
            {
                case "Technology": TypeInt = 1; break;
                case "Edit": TypeInt = 2; break;
                case "Essay": TypeInt = 3; break;
            }
            return base.SearchCount(d => d.Article_IsDel == false && d.Article_Type == TypeInt);
        }

        public List<Common.Models.Article> GetArticleList(int pageIndex, int pageSize)
        {
            return base.Search(d => d.Article_IsDel == false, d => d.Article_Time, pageIndex, pageSize);
        }

        public bool AddArticle(string title, string brief, string body,string type,string path)
        {
            string url = DateTime.Now.ToString("yyyyMMddHHmmssssss");
            Common.Models.Article article = new Common.Models.Article()
            {
                Article_Title = title,
                Article_Abstract = brief,
                Article_Time = DateTime.Now,
                Article_IsDel = false,
                Article_UserId = 1,
                Article_Id = 1,
                Article_Type = Convert.ToInt32(type),
                Article_Url = url
            };
            base.Add(article);
            new HtmlOperation().AddHtml(path + url + ".cshtml", body, title,DateTime.Now.ToString("yyyy年MM月dd日"));
            return true;
        }
    }
}
