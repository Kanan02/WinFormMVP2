using MVP2.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP2.View
{
    public interface IUserView
    {
        List<string> Posts
        {
            get;
            set;
        }
        string FullName
        {
            get;
            set;
        }
        string UserName
         {
            get;
            set;
         }
         string Password
         {
            get;
            set;
         }
        UserPresenter userPresenter { get; set; }
       

    }
}
