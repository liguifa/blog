using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService
{
    public class DemoOper:BaseBLL<Common.Models.demo>
    {
        public List<Common.Models.demo> GetListToPage(string pageIndex)
        {
            int index=Convert.ToInt32(pageIndex);
            int size = 20;
            int dataPageSize = this.GetDataPageNumber(size);
            index = index <= 0 ? 1 : Convert.ToInt64(index) <= dataPageSize?index:dataPageSize;
            return base.Search(d => d.demo_IsDel == false, d => d.demo_Id, index, size);
        }

        public int GetDataPageNumber(int pageSize)
        {
            long dataSize=base.SearchCount(d => d.demo_IsDel == false);
            double temp = Convert.ToInt32(dataSize) / pageSize;
            return Convert.ToInt32(Math.Ceiling(temp));
        }
    }
}
