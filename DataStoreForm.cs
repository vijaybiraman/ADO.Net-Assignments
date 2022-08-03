using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ClassLibDemo
{
    public class DataStoreForm
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        SqlDataReader reader = null;

        public DataStoreForm(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public List<Login> ValidateUser()
        {
            try
            {
                
                string sql = "Select Username,password from UserData";
                command = new SqlCommand(sql, connection);
              
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                List<Login> users = new List<Login>();
                while (reader.Read())
                {
                    Login login = new Login();
                    login.username= reader["UserName"].ToString();
                    login.password = reader["Password"].ToString();
                   
                    users.Add(login);
                }

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            
        }
    }
}


    
