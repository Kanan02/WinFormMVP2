using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP2.Model
{
    public class User
    {
        public User(string fullName, string userName, string password, List<string> posts)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Posts = posts;
        }
        public User()
        {

        }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Posts { get; set; }


    }
}
