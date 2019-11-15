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
    public partial class PurchaseForm : Form
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        Purchase purchase = new Purchase();

        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            DataTable dataTable = _purchaseManager.FillDD();
            foreach (DataRow dr in dataTable.Rows)
            {
                productComboBox.Items.Add(dr["ProductName"].ToString());
            }

            DataTable dataTble = _purchaseManager.FillDealerName();
            foreach (DataRow dr in dataTble.Rows)
            {
                dealerComboBox.Items.Add(dr["DealerName"].ToString());
            }
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = productComboBox.Text;
            DataTable dataTble = _purchaseManager.FillLabel(selectedProduct);

            foreach (DataRow dr in dataTble.Rows)
            {
                unitLabel.Text = dr["Units"].ToString();
            }
        }

        private void priceTextBox_Leave(object sender, EventArgs e)
        {
            totalTextBox.Text = (Convert.ToInt32(qtyTextBox.Text) * Convert.ToInt32(priceTextBox.Text)).ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            purchase.ProductName = productComboBox.Text;
            purchase.ProductQty = Convert.ToInt32(qtyTextBox.Text);
            purchase.ProductUnit = unitLabel.Text;
            purchase.ProductPrice = Convert.ToDouble(priceTextBox.Text);
            purchase.ProductTotal = Convert.ToDouble(totalTextBox.Text);
            purchase.PurchaseDate = purchaseDate.Value.ToString("dd-MM-yyyy");
            purchase.PurchasePartyName = dealerComboBox.Text;
            purchase.PurchaseType = purchaseTypeComboBox.Text;
            purchase.ExpireDate = expireDate.Value.ToString("dd-MM-yyyy");
            purchase.Profit = Convert.ToDouble(profitTextBox.Text);

            if (productComboBox.Text == ""|| qtyTextBox.Text == ""|| priceTextBox.Text == "")
            {
                MessageBox.Show("Field must not be empty..");
            }

            if (!_purchaseManager.IsStock(productComboBox.Text))
            {
                if (_purchaseManager.Add(purchase))
                {
                    if (_purchaseManager.AddStock(purchase))
                    {
                        MessageBox.Show("Added");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Not Added");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Not Added");
                    return;
                }
            }
            else
            {
                if (_purchaseManager.Add(purchase))
                {
                    if (_purchaseManager.UpdateStock(purchase))
                    {
                        MessageBox.Show("Update Added");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Not Update Added");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Not Added");
                    return;
                }
            }
        }
    }
}
