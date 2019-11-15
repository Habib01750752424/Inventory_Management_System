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
    public class LoginRegisterRepository
    {
        string connectionString = @"Server = HABIB; Database = InventoryManagement; Integrated Security = true";

        public bool Login(Register register)
        {
            bool isLogin = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Registration WHERE UserName = '" + register.UserName + "' AND Password = '"+register.Password+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                isLogin = true;
            }
            return isLogin;
        }

        public bool Add(Register register)
        {
            bool isAdd = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO Registration(FirstName, LastName,UserName,Password,Email,Contact)" +
                "VALUES('"+ register.FirstName + "','" + register.LastName + "','" + register.UserName + "'," +
                "'" + register.Password + "','" + register.Email + "','" + register.Contact + "')";
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

        public bool IsCustomerExist(Register register)
        {
            bool isExist = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT UserName FROM Registration WHERE UserName = '" + register.UserName+"'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                isExist = true;
            }
            sqlConnection.Close();
            return isExist;
        }

        public List<Register> Display()
        {
            List<Register> registers = new List<Register>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM Registration";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Register register = new Register();
                register.Id = Convert.ToInt32(sqlDataReader["Id"]);
                register.FirstName = sqlDataReader["FirstName"].ToString();
                register.LastName = sqlDataReader["LastName"].ToString();
                register.UserName = sqlDataReader["UserName"].ToString();
                register.Password = sqlDataReader["Password"].ToString();
                register.Email = sqlDataReader["Email"].ToString();
                register.Contact = sqlDataReader["Contact"].ToString();

                registers.Add(register);
            }
            sqlConnection.Close();

            return registers;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "DELETE Registration WHERE Id = "+id+"";
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
