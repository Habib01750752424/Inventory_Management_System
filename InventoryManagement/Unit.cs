using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagement.BLL;
using InventoryManagement.Model;

namespace InventoryManagement
{
    public partial class Unit : Form
    {
        UnitManager _unitManager = new UnitManager();
        _Unit unit = new _Unit();
        public Unit()
        {
            InitializeComponent();
        }

        private void unitButton_Click(object sender, EventArgs e)
        {
            unit.Units = unitTextBox.Text;
            if (_unitManager.Add(unit))
            {
                MessageBox.Show("Added");
                showDataGridView.DataSource = _unitManager.Display();
            }
            else
            {
                MessageBox.Show("Not Added");
            }

        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(showDataGridView.SelectedCells[0].Value);

            if (_unitManager.Delete(id))
            {
                MessageBox.Show("Deleted Successfully..");
                showDataGridView.DataSource = _unitManager.Display();
                return;
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
        }

        private void Unit_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _unitManager.Display();
        }
    }
}
