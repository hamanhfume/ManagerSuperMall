using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMallManagerMVC
{
    public partial class LoginForm : Form
    {
        public Account Acc;
        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
            Acc = new Account();
        }

        private void buttonCancelForm_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttonCancelForm))
            {
                Dispose();
            }
        }

        private void buttonLoginForm_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            if (userName.Equals(Acc.UserName) && password.Equals(Acc.Password))
            {
                HomeForm home = new HomeForm();
                // Close the LoginForm when the HomeForm is closed
                home.FormClosed += (s, args) => this.Close();
                home.Show();
                // Hide the LoginForm instead of closing it immediately
                this.Hide();
            }
            else
            {
                string content = "Please check your account or password!";
                string title = "Notification: ";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

    public class Run
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            LoginForm form = new LoginForm();
            Application.Run(form);
        }
    }
}
