using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagement.Repository
{
    public class DealerRepository
    {
        string connectionString = @"Server=HABIB;Database=InventoryManagement; Integrated Security = true;";
        Dealer dealer = new Dealer();

        public bool Add(Dealer dealer)
        {
            bool isAdd = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"INSERT INTO DealarInfo(DealerName,DealerCompanyName,Contact,Address,City)
             VALUES('" + dealer.DealerName+"','"+dealer.DealerCompanyName+"','"+dealer.Contact+"'," +
             "'"+dealer.Address+"','"+dealer.City+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            int isExecute =  sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isAdd = true;
            }
            sqlConnection.Close();
            return isAdd;
        }

        public bool Update(Dealer dealer,int id)
        {
            bool isUpdate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"UPDATE DealarInfo SET DealerName = '" + dealer.DealerName + "'," +
                "DealerCompanyName = '" + dealer.DealerCompanyName + "',Contact = '" + dealer.Contact + "'," +
                "Address = '" + dealer.Address + "',City = '" + dealer.City + "' WHERE Id = "+id+"";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isUpdate = true;
            }
            sqlConnection.Close();
            return isUpdate;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"DELETE DealarInfo  WHERE Id = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isDelete = true;
            }
            sqlConnection.Close();
            return isDelete;
        }

        public List<Dealer> Display()
        {
            List<Dealer> dealers = new List<Dealer>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM DealarInfo";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Dealer dealer = new Dealer();
                dealer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                dealer.DealerName = sqlDataReader["DealerName"].ToString();
                dealer.DealerCompanyName = sqlDataReader["DealerCompanyName"].ToString();
                dealer.Contact = sqlDataReader["Contact"].ToString();
                dealer.Address = sqlDataReader["Address"].ToString();
                dealer.City = sqlDataReader["City"].ToString();

                dealers.Add(dealer);
            }
            sqlConnection.Close();
            return dealers;
        }
    }
}
