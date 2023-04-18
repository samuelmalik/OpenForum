using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

/*using static Java.Util.Jar.Attributes;*/

namespace OpenForum.Service
{
    public class UserService
    {
        public static string connectionString = "server=localhost;database=open_forum_db;username=root;password=password";

        public static string GetPassword(string username)
        {
            string password = null;



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // query
                string query = "SELECT usr_password FROM users WHERE username = @Username";

                // command and parameters
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            password = reader["usr_password"].ToString();
                        }
                    }
                }

                connection.Close();
            }




            return password;
        }
    }
}
