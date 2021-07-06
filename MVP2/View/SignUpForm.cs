using MVP2.Model;
using MVP2.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP2.View
{
    public partial class SignUpForm : Form,IUserView
    {
        FirstForm form;
        public SignUpForm(FirstForm form)
        {
            InitializeComponent();
            this.form = form;
            userPresenter = form.userPresenter;
            userPresenter.ChangeView(this);
        }

        public List<string> Posts { get ; set; }
        public string FullName { get ; set; }
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
        public UserPresenter userPresenter { get; set ; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                FullName = textBox1.Text;
                UserName = textBox2.Text;
                Password = textBox3.Text;
                Posts = new List<string>();
                List<User> users= userPresenter.GetAllUsers() as List<User>;
                foreach (var item in users)
                {
                    if (item.UserName==UserName )
                    {
                        MessageBox.Show("There is already an account with such username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                
                userPresenter.AddUser();
                MessageBox.Show("Successful Registration!","Registered",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
