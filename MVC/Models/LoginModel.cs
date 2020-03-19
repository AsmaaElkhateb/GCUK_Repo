using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool RememberMe { get; set; }

        public bool IsValid(string _username, string _password)
        {
            List<SecurityUser> UserList = GetAllUser();
            if (UserList.Where(a => a.UserName == _username && a.Password == _password).Any())
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public List<SecurityUser> GetAllUser()
        {
            List<SecurityUser> _SecurityUserList = new List<SecurityUser>
            {
                new SecurityUser  { Id = 1, FullName = "Admin", UserName = "Admin", Password = "123" },
                new SecurityUser  { Id = 2, FullName = "Social", UserName = "Social", Password = "456" },
                new SecurityUser  { Id = 3, FullName = "Observer", UserName = "Observer", Password = "789" }
            };
            return _SecurityUserList;
        }
    }
}