using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagement.Model;
using InventoryManagement.BLL;

namespace InventoryManagement
{
    public partial class Add_Product : Form
    {
        AddProductManager _addProductManager = new AddProductManager();
        Product product = new Product();
        int id;

        public Add_Product()
        {
            InitializeComponent();
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {
            DataTable dataTable = _addProductManager.FillDD();
            foreach (DataRow dr in dataTable.Rows)
            {
                unitComboBox.Items.Add(dr["Units"].ToString());
            }

            List<Product> products = _addProductManager.Display();
            showDataGridView.DataSource = products;
            //unitComboBox.DataSource = _addProductManager.LoadUnit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Product product = new Product();
            string productName = nameTextBox.Text;
            string unit = unitComboBox.SelectedItem.ToString();

            if (_addProductManager.Add(productName,unit))
            {
                MessageBox.Show("Added");
                List<Product> products = _addProductManager.Display();
                showDataGridView.DataSource = products;
                return;
            }
            else
            {
                MessageBox.Show("Not Added");
            }
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updatePanel.Visible = true;
            
            try
            {
                id = Convert.ToInt32(showDataGridView.SelectedCells[0].Value.ToString());
                DataTable dataTable = _addProductManager.FillDD();
                updateUnitComboBox.Items.Clear();
                foreach (DataRow dr in dataTable.Rows)
                {
                    updateUnitComboBox.Items.Add(dr["Units"].ToString());
                }


                DataTable dataTble = _addProductManager.SelectedUnit(id);
                foreach (DataRow dr in dataTble.Rows)
                {
                    updateTextBox.Text = dr["ProductName"].ToString();
                    updateUnitComboBox.SelectedItem = dr["Units"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select Id Column");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string productName = updateTextBox.Text;
            string unit = updateUnitComboBox.SelectedItem.ToString();

            if (_addProductManager.Update(productName, unit,id))
            {
                MessageBox.Show("Updated");
                List<Product> products = _addProductManager.Display();
                showDataGridView.DataSource = products;
                return;
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
