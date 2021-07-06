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
    public partial class FirstForm : Form,IUserView
    {
        public FirstForm()
        {
            InitializeComponent();
        }
        public string UserName
        {
            get { return userNameTextBox.Text; }
            set { userNameTextBox.Text = value; }
        }
        public string Password
        {
            get { return passwordTextBox.Text; }
            set { passwordTextBox.Text = value; }
        }
        public UserPresenter userPresenter { get; set; }
        public List<string> Posts { get ; set ; }
        public string FullName { get; set; }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (userPresenter.isValid())
            {
                
                PostPageForm postPageForm = new PostPageForm(this);
                
                postPageForm.ShowDialog();
                userPresenter.ChangeView(this);
            }
            else
            {
                MessageBox.Show("Invalid Username or Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm form = new SignUpForm(this);
            form.ShowDialog();
            userPresenter.ChangeView(this);

        }
    }
}
