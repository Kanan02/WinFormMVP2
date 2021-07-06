using MVP2.Model;
using MVP2.Repository;
using MVP2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP2.Presenter
{
    public class UserPresenter
    {
        IUserView view;
        IUserRepository repository;
        int id;
        public UserPresenter(IUserView view, IUserRepository repository)
        {
            view.userPresenter = this;
            this.view = view;
            this.repository = repository;
            

        }
        public void ChangeView(IUserView view)
        {
            this.view = view;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAllUsers();
        }
        public void SaveUser()
        {
            User user = new User(view.FullName, view.UserName, view.Password,view.Posts);
            
            repository.SaveUser(id,user);
            
        }
        public void AddUser()
        {
            User user = new User(view.FullName, view.UserName, view.Password, view.Posts);
            repository.AddUser(user);
        }
        public bool isValid()
        {
            bool valid = false;
            int i = 0;
            foreach (var item in repository.GetAllUsers())
            {
                if (item.UserName==view.UserName&&item.Password==view.Password)
                {
                    id = i;
                    valid = true;
                    view.FullName = item.FullName;
                    view.Posts = item.Posts;
                    
                    break;
                }
                i++;
            }
            return valid;
        }
        
    }
}
