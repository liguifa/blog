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
    }
}
