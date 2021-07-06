using MVP2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MVP2.Repository
{
    public class UserRepository : IUserRepository
    {
        public string xmlPath { get; set; }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
        List<User> users;

        public UserRepository(string path)
        {
            xmlPath = path + "\\users.xml";
            if (!File.Exists(xmlPath))
            {
                XmlFakeRepo();
            }
            users = new List<User>();


            using (var ser = new StreamReader(xmlPath))
            {
                users = (List<User>)xmlSerializer.Deserialize(ser);
            }

        }
        void XmlFakeRepo()
        {
            List<User> customerList = new List<User> {
                new User("John Doe","Johny","12345",new List<string>(){ "Hello"}),
              
            };
            SaveUsers(customerList);
        }


        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }
        public void SaveUsers(List<User> _users)
        {
            using (var ser = new StreamWriter(xmlPath))
            {
                xmlSerializer.Serialize(ser, _users);
            }

        }
        public void SaveUser(int id, User user)
        {
            users[id]=user;
            SaveUsers(users);
        }
        
        public User GetUserById(int id)
        {
            return users[id];
        }
        public void AddUser(User user)
        {
            users.Add(user);
            SaveUsers(users);
        }

    }
}
