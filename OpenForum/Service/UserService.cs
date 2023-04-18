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

        public static string GetPassword()
        {
            string password = null;



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT usr_password FROM users WHERE username = 'zasko789'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            password = reader.GetString(0);
                        }
                    }
                }

                connection.Close();
            }




            return password;
        }
    }
}
