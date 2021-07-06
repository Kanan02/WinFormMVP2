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
    public partial class PostPageForm : Form,IUserView
    {
        FirstForm form;
        bool editPressed = false;
        List<Label> labels = new List<Label>();
        List<Button> buttons = new List<Button>();
        Label chosenLabel;
        
        public PostPageForm(FirstForm form)
        {
            InitializeComponent();
            this.form = form;

            this.userPresenter = form.userPresenter;
            
            usernameLabel.Text = form.UserName;

            fullNameLabel.Text = form.FullName;
            ShowPosts();
        }

        public List<string> Posts { get; set ; }
        public string FullName { get { return fullNameLabel.Text; } set { fullNameLabel.Text = value; } }
        public string UserName { get { return usernameLabel.Text; } set { usernameLabel.Text = value; } }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public UserPresenter userPresenter { get ; set ; }
        
       
        
        void ShowPosts()
        {
            int Ypos=220;
            
            for (int i = 0; i < form.Posts.Count; i++)
            {
                Label label = new Label();

                Controls.Add(label);
                label.Text = form.Posts[i];
                label.AutoSize = true;
                label.Location = new Point(60, Ypos);
                
                label.Name = $"{i + 1}";
                labels.Add(label);
                Button button = new Button();
                Controls.Add(button);
                button.Name = $"{i + 1}";
                button.Text = "Edit";
                button.Click += new System.EventHandler(this.EditButton_Click);
                Ypos = label.Location.Y + label.Size.Height +5;
                button.Location = new Point(60, Ypos);
                buttons.Add(button);
                Ypos += 30;
            }
        }
        void UpdatePosts()
        {
            int Ypos = 220;

            for (int i = 0; i < form.Posts.Count; i++)
            {
                labels[i].Location = new Point(60, Ypos);
               
                Ypos = labels[i].Location.Y + labels[i].Size.Height + 5;
                buttons[i].Location = new Point(60, Ypos);
               
                Ypos += 30;
            }
        }
        private void EditButton_Click(object sender,EventArgs e)
        {
            editPressed = true;
            string but_name = (sender as Button).Name;
            
            foreach (var item in labels)
            {
                if (but_name== item.Name)
                {
                    textBox1.Text = item.Text;
                    chosenLabel = item;
                    
                }
            }
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editPressed)
            {
                for (int i = 0; i < form.Posts.Count; i++)
                {
                    if (chosenLabel.Text==form.Posts[i])
                    {
                        form.Posts[i] = textBox1.Text;
                        chosenLabel.Text = textBox1.Text;
                        
                        break;
                    }
                }
                
            }
            else
            {
                form.Posts.Add(textBox1.Text);
                Label label = new Label();
                label.Text = textBox1.Text;
                label.AutoSize = true;
                Controls.Add(label);
                label.Name = $"{labels.Count + 1}";
                labels.Add(label);
                Button button = new Button();
                button.Name = label.Name;
                button.Text = "Edit";
                Controls.Add(button);
                button.Click += new System.EventHandler(this.EditButton_Click);
                buttons.Add(button);
            }
            UpdatePosts();
            userPresenter.SaveUser();
            editPressed = false;
        }
    }
}
