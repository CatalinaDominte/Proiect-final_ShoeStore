using Project.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
   public class ManageAccountsRepository:IManageAccountsRepository
    {
        private readonly SqlConnection connection;

        public ManageAccountsRepository(SqlConnection connection)
        {
            this.connection = connection;

        }
        public List<ManageAccounts> GetAll()
        {
            List<ManageAccounts> Accounts = new List<ManageAccounts>();

            SqlCommand command = new SqlCommand("GetDetailAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    ManageAccounts accounts = new ManageAccounts();
                    accounts.Id = (int)currentRow["Id"];
                    accounts.Name = currentRow["username"].ToString();
                    accounts.Password = currentRow["password"].ToString();
                    accounts.Role_id = (int)currentRow["role_id"];

                    Accounts.Add(accounts);
                }
            }
            return
                Accounts;
        }
        public ManageAccounts GetDetails(int id)
        {
            ManageAccounts accounts = new ManageAccounts();

            SqlCommand command = new SqlCommand("GetDetailAccounts", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    
                    var currentRow = dataReader;
                    accounts.Id = (int)currentRow["Id"];
                    accounts.Name = currentRow["username"].ToString();
                    accounts.Password = currentRow["password"].ToString();
                    accounts.Role_id = (int)currentRow["role_id"];
                }
                return accounts;
            }
        }
        public int Create(ManageAccounts accounts)
        {


            SqlCommand cmd = new SqlCommand("CreateAccounts", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@1", accounts.Name);
                cmd.Parameters.AddWithValue("@2", accounts.Password);
                cmd.Parameters.AddWithValue("@3", accounts.Role_id);
                
                int i = cmd.ExecuteNonQuery();

                return i;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        
        public int Delete(int id)
        {

            SqlCommand cmd = new SqlCommand("DeleteAccounts", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        public int Update(ManageAccounts accounts, int id)
        {

            SqlCommand cmd = new SqlCommand("UpdateAccounts", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@1", accounts.Name);
            cmd.Parameters.AddWithValue("@2", accounts.Password);
            cmd.Parameters.AddWithValue("@3", accounts.Role_id);

            cmd.Parameters.AddWithValue("@Id", id);

            int i = cmd.ExecuteNonQuery();

            return i;

        }
    }
}
