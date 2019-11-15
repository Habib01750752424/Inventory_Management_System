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
    public partial class Sales : Form
    {
        DataTable dt = new DataTable();
        PurchaseManager _purchaseManager = new PurchaseManager();
        Purchase purchase = new Purchase();
        OrderUser orderUser = new OrderUser();
        OrderItem orderItem = new OrderItem();
        int tot = 0;

        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            dt.Clear();
            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
        }

        private void productTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            purchase.ProductName = productTextBox.Text;
            listBox1.Visible = true;
            listBox1.Items.Clear();

            DataTable dataTable = _purchaseManager.Search(purchase);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                listBox1.Items.Add(dataRow["ProductName"].ToString());
            }
        }

        private void productTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex + 1;
                }

                if (e.KeyCode == Keys.Up)
                {
                    this.listBox1.SelectedIndex = this.listBox1.SelectedIndex - 1;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    productTextBox.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    priceTextBox.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void priceTextBox_Enter(object sender, EventArgs e)
        {
            purchase.ProductName = productTextBox.Text;
            DataTable dataTable = _purchaseManager.PriceSelect(purchase);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                priceTextBox.Text = dataRow["ProductPrice"].ToString();
            }
        }

        private void quantityTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                totalTextBox.Text = (Convert.ToDouble(priceTextBox.Text) * Convert.ToDouble(quantityTextBox.Text)).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            purchase.ProductName = productTextBox.Text;
            int quantity = Convert.ToInt32(quantityTextBox.Text);
            int stockQty = 0;

            //DataTable dataTable = _purchaseManager.SelectQuantity(purchase);
            DataTable dataTable = _purchaseManager.SelectQuantity(purchase);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                stockQty = Convert.ToInt32(dataRow["ProductQty"].ToString());
            }

            if (stockQty < quantity)
            {
                MessageBox.Show("Sorry..! There is no more available this quantity..");
            }
            else
            {
                //dt.Clear();
                //dt.Columns.Add("Product");
                //dt.Columns.Add("Price");
                //dt.Columns.Add("Quantity");
                //dt.Columns.Add("Total");

                DataRow dr = dt.NewRow();
                dr["Product"] = productTextBox.Text;
                dr["price"] = priceTextBox.Text;
                dr["Quantity"] = quantityTextBox.Text;
                dr["Total"] = totalTextBox.Text;
                dt.Rows.Add(dr);
                showDataGridView.DataSource = dt;

                tot = tot + Convert.ToInt32(dr["Total"].ToString());
                totalLabel.Text = tot.ToString();
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                tot = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(showDataGridView.CurrentCell.RowIndex.ToString()));
                foreach (DataRow dataRow1 in dt.Rows)
                {
                    tot = tot + Convert.ToInt32(dataRow1["Total"].ToString());
                    totalLabel.Text = tot.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No available data");
            }
        }

        private void savePrintButton_Click(object sender, EventArgs e)
        {
            orderUser.FirstName = firstNameTextBox.Text;
            orderUser.LastName = lastNameTextBox.Text;
            orderUser.BillType = billTypeTextBox.Text;
            orderUser.PurchaseDate = billDate.Value.ToString("dd-MM-yyyy");
            int OrderUserId = 0;

            bool isAddOrderUser = _purchaseManager.AddOrderUser(orderUser);

            DataTable dataTable1 = _purchaseManager.OUserId();
            foreach (DataRow dr in dataTable1.Rows)
            {
                OrderUserId = Convert.ToInt32(dr["Id"].ToString());
            }

            foreach (DataRow dr in dt.Rows)
            {
                orderItem.Product = dr["Product"].ToString();
                orderItem.Price = Convert.ToDouble(dr["Price"].ToString());
                orderItem.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                orderItem.Total = Convert.ToInt32(dr["Total"].ToString());

                bool isAddOrderItem = _purchaseManager.AddOrderItem(orderItem,OrderUserId);

                _purchaseManager.UpdateStockQty(orderItem);
            }

            dt.Clear();
            showDataGridView.DataSource = dt;
            MessageBox.Show("Iserted Successfully..");
        }
    }
}
