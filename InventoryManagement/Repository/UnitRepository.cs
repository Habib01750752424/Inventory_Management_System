using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;

namespace InventoryManagement.Repository
{
    public class UnitRepository
    {
        string connectionString = @"Server = HABIB; Database = InventoryManagement; Integrated Security = true";
        public bool Add(_Unit unit)
        {
            bool isAdd = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO tblUnit(Units)" +
                "VALUES('" + unit.Units + "')";
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

        public List<_Unit> Display()
        {
            List<_Unit> units = new List<_Unit>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM tblUnit";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                _Unit unit = new _Unit();
                unit.Id = Convert.ToInt32(sqlDataReader["Id"]);
                unit.Units = sqlDataReader["Units"].ToString();

                units.Add(unit);
            }
            sqlConnection.Close();

            return units;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "DELETE tblUnit WHERE Id = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();
            if (isExecute > 0)
            {
                isDelete = true;
            }
            sqlConnection.Close();
            return isDelete;
        }
    }
}
