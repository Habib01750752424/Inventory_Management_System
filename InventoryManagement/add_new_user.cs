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
    public partial class add_new_user : Form
    {
        LoginRegisterManager _loginRegisterManager = new LoginRegisterManager();
        Register register = new Register();

        public add_new_user()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            register.FirstName = firstNameTextBox.Text;
            register.LastName = lastNameTextBox.Text;
            register.UserName = userNameTextBox.Text;
            register.Password = passwordTextBox.Text;
            register.Email = emailTextBox.Text;
            register.Contact = contactTextBox.Text;

            if (_loginRegisterManager.IsCustomerExist(register))
            {
                MessageBox.Show("Customer is already exist..");
                return;
            }

            if (_loginRegisterManager.Add(register))
            {
                MessageBox.Show("User Added Successfully..");
                showDataGridView.DataSource = _loginRegisterManager.Display();
            }
            else
            {
                MessageBox.Show("Please Check Inserting Details..");
            }
        }

        private void add_new_user_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _loginRegisterManager.Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            //MessageBox.Show(showDataGridView.SelectedCells[0].Value.ToString());
            id = Convert.ToInt32(showDataGridView.SelectedCells[0].Value);

            if (_loginRegisterManager.Delete(id))
            {
                MessageBox.Show("Deleted Successfully");
                showDataGridView.DataSource = _loginRegisterManager.Display();
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

        }
    }
}
