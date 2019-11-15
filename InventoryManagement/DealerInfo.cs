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
    public partial class DealerInfo : Form
    {
        DealerManager _dealerManager = new DealerManager();
        Dealer dealer = new Dealer();

        int id;

        public DealerInfo()
        {
            InitializeComponent();
        }

        private void dealerButton_Click(object sender, EventArgs e)
        {
            string dealerName = nameTextBox.Text;
            string dealerCompanyName = cNameTextBox.Text;
            string contact = contactTextBox.Text;
            string address = addressTextBox.Text;
            string city = cityTextBox.Text;

            dealer.DealerName = nameTextBox.Text;
            dealer.DealerCompanyName = cNameTextBox.Text;
            dealer.Contact = contactTextBox.Text;
            dealer.Address = addressTextBox.Text;
            dealer.City = cityTextBox.Text;

            if (dealerName == ""|| dealerCompanyName == ""||contact == ""|| address == ""||city == "")
            {
                MessageBox.Show("Please Field must not be empty..");
                return;
            }

            if (_dealerManager.Add(dealer))
            {
                MessageBox.Show("Added");
                List<Dealer> dealers = _dealerManager.Display();
                showDataGridView.DataSource = dealers;
                return;
            }
            else
            {
                MessageBox.Show("Not Added");
            }
        }

        private void DealerInfo_Load(object sender, EventArgs e)
        {
            List<Dealer> dealers = _dealerManager.Display();
            showDataGridView.DataSource = dealers;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dealer.DealerName = nameTextBox.Text;
            dealer.DealerCompanyName = cNameTextBox.Text;
            dealer.Contact = contactTextBox.Text;
            dealer.Address = addressTextBox.Text;
            dealer.City = cityTextBox.Text;

            if (_dealerManager.Update(dealer,id))
            {
                MessageBox.Show("Updated");
                List<Dealer> dealers = _dealerManager.Display();
                showDataGridView.DataSource = dealers;
                return;
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (showDataGridView.CurrentRow.Index != -1)
            {
                id = Convert.ToInt32(showDataGridView.CurrentRow.Cells[0].Value.ToString());
                nameTextBox.Text = showDataGridView.CurrentRow.Cells[1].Value.ToString();
                cNameTextBox.Text = showDataGridView.CurrentRow.Cells[2].Value.ToString();
                contactTextBox.Text = showDataGridView.CurrentRow.Cells[3].Value.ToString();
                addressTextBox.Text = showDataGridView.CurrentRow.Cells[4].Value.ToString();
                cityTextBox.Text = showDataGridView.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_dealerManager.Delete(id))
            {
                MessageBox.Show("Deleted");
                List<Dealer> dealers = _dealerManager.Display();
                showDataGridView.DataSource = dealers;
                return;
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
        }
    }
}
