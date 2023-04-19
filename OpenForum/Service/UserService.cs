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
        
        // get password by username
        public async static Task<string> GetPassword(string username)
        {
            string password = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // query
                string query = "SELECT usr_password FROM users WHERE username = @Username";

                // command and parameters
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            password = reader["usr_password"].ToString();
                        }
                    }
                }
            }
            return password;
        }

        // get user id by username
        public async static Task<int> GetId(string username)
        {
            int id = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // query
                string query = "SELECT user_id FROM users WHERE username = @Username";

                // command and parameters
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            id = Convert.ToInt32(reader["user_id"]);
                        }
                    }
                }
            }
            return id;
        }

        // return if username exist
        public async static Task<bool> UsernameExist(string username)
        {
            string usernameInDB = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // query
                string query = "SELECT username FROM users WHERE username = @Username";

                // command and parameters
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                           usernameInDB = reader["username"].ToString();
                        }
                    }
                }
            }
            return username == usernameInDB;
        }
    }
        

}
