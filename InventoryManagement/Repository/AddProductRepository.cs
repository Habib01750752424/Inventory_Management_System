using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;

namespace InventoryManagement.Repository
{
    public class AddProductRepository
    {
        string connectionString = @"Server = HABIB; Database = InventoryManagement; Integrated Security = true";

        public DataTable FillDD()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM tblUnit";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //foreach (DataRow dr in dataTable.Rows)
            //{
            //    unitComboBox.Items.Add(dr["Units"].ToString());
            //}
            sqlConnection.Close();
            return dataTable;
        }

        public DataTable SelectedUnit(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Products WHERE Id = "+id+"";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }

        public bool Add(string productName,string unit)
        {
            bool isAdd = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO Products(ProductName, Units)" +
                "VALUES('" + productName + "','" + unit + "')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();
            if (isExecute > 0)
            {
                isAdd = true;
            }
            sqlConnection.Close();
            return isAdd;
        }

        public bool Update(string productName, string unit,int id)
        {
            bool isUpdate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "UPDATE Products SET ProductName = '"+productName+"'" +
                ",Units = '"+unit+"' WHERE Id = "+id+"";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();
            if (isExecute > 0)
            {
                isUpdate = true;
            }
            sqlConnection.Close();
            return isUpdate;
        }

        public List<Product> Display()
        {
            List<Product> products = new List<Product>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM Products";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(sqlDataReader["Id"]);
                product.ProductName = sqlDataReader["ProductName"].ToString();
                product.Units = sqlDataReader["Units"].ToString();

                products.Add(product);
            }
            sqlConnection.Close();

            return products;
        }


        public List<_Unit> LoadUnit()
        {
            List<_Unit> units = new List<_Unit>();
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @"SELECT * FROM tblUnit";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                _Unit unit = new _Unit();
                unit.Units = sqlDataReader["Units"].ToString();
                units.Add(unit);
            }

            sqlConnection.Close();
            return units;
        }
    }
}
