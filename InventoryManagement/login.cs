using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagement.Model;
using InventoryManagement.BLL;

namespace InventoryManagement
{
    public partial class login : Form
    {
        LoginRegisterManager _loginRegisterManager = new LoginRegisterManager();
        Register register = new Register();
        public login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            register.UserName = uTextBox.Text;
            register.Password = pTextBox.Text;
            if (_loginRegisterManager.Login(register))
            {
                this.Hide();
                MDIParent mdiParent = new MDIParent();
                mdiParent.Show();
            }
            else
            {
                MessageBox.Show("Username or Password does not match..");
            }
        }
    }
}
