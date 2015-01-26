using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService
{
    public class UserOper:BaseBLL<Common.Models.User>
    {
        public bool Login(string username, string password)
        {
            string pwd = Md5.GetMd5Word(username, password);
            List <Common.Models.User> users=base.Search(d => d.User_Name == username && d.User_IsDel == false);
            return users.Count() >= 1 && users[0].User_Pwd == pwd;
        }

        public List<Common.Models.User> GetUserList()
        {
            return base.Search(d => d.User_IsDel == false);
        }
    }
}
