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

        // add new user to database
        public async static Task AddUser(User user)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "INSERT INTO users (username, usr_password, is_admin, xp) VALUES (@username, @usr_password, @is_admin, @xp)";
            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", user.Name);
            command.Parameters.AddWithValue("@usr_password", user.Pass);
            command.Parameters.AddWithValue("@is_admin", user.IsAdmin);
            command.Parameters.AddWithValue("@xp", user.Xp);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        // get user by username
        public async static Task<User> GetUserByUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // query
                string query = "SELECT * FROM users WHERE username = @Username";

                // command and parameters
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new User
                            {
                                Id = reader["user_id"].ToString(),
                                Name = username,
                                Pass = reader["usr_password"].ToString(),
                                IsAdmin = Convert.ToInt32(reader["is_admin"]),
                                Note = reader["note"].ToString(),
                                Xp = Convert.ToInt32(reader["xp"]),
                                Status = reader["status"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // get all users
        public async static Task<User> GetAllUsers()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                await connection.OpenAsync();

                // query
                string query = "SELECT * FROM users ORDER BY is_admin DESC, username";

                // command and parameters
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = new User
                            {
                                Id = reader["user_id"].ToString(),
                                Name = reader["username"].ToString(),
                                Pass = reader["usr_password"].ToString(),
                                IsAdmin = Convert.ToInt32(reader["is_admin"]),
                                Note = reader["note"].ToString(),
                                Xp = Convert.ToInt32(reader["xp"]),
                                Status = reader["status"].ToString(),
                                
                                Slack = reader["achievements"].ToString().Contains(",1,"),
                                Discord = reader["achievements"].ToString().Contains(",2,"),
                                Aktivita = reader["achievements"].ToString().Contains(",3,"),
                                Rychlost = reader["achievements"].ToString().Contains(",4,"),
                                Pomocnik = reader["achievements"].ToString().Contains(",5,"),
                                Nacas = reader["achievements"].ToString().Contains(",6,"),
                                DobryNapad = reader["achievements"].ToString().Contains(",7,"),
                                ChristmassCoder = reader["achievements"].ToString().Contains(",8,"),
                                Presenter = reader["achievements"].ToString().Contains(",9,"),
                                QuizzMaster = reader["achievements"].ToString().Contains(",10,"),
                                GitHub = reader["achievements"].ToString().Contains(",11,"),
                                Cvicenia10 = reader["achievements"].ToString().Contains(",12,"),
                                Cvicenia20 = reader["achievements"].ToString().Contains(",13,"),
                                Cvicenia30 = reader["achievements"].ToString().Contains(",14,"),
                                Cvicenia40 = reader["achievements"].ToString().Contains(",15,"),
                                Cvicenia50 = reader["achievements"].ToString().Contains(",16,"),
                                GildedRose = reader["achievements"].ToString().Contains(",17,"),
                                OOPBasics = reader["achievements"].ToString().Contains(",18,"),
                                HousingEstate = reader["achievements"].ToString().Contains(",19,"),
                                CodingGame = reader["achievements"].ToString().Contains(",20,"),
                                CGHorseRacing = reader["achievements"].ToString().Contains(",21,"),
                                CGTemperatures = reader["achievements"].ToString().Contains(",22,"),
                                CGCircuitResistance = reader["achievements"].ToString().Contains(",23,"),
                                HelloXamarin = reader["achievements"].ToString().Contains(",24,"),
                                BeatsPerMinute = reader["achievements"].ToString().Contains(",25,"),
                                Mvvm = reader["achievements"].ToString().Contains(",26,"),
                                Stopwatch = reader["achievements"].ToString().Contains(",27,"),
                                Puzzle = reader["achievements"].ToString().Contains(",28,")



                            };
                            User.All.Add(user);
                        }
                    }
                }
            }
            return null;
        }

        // update user's status
        public async static Task UpdateStatus(string id, string status)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "UPDATE users SET status = @status  WHERE user_id = @id";
            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@id", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        // update user's note
        public async static Task UpdateAdminNote(string id, string note)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "UPDATE users SET note = @note  WHERE user_id = @id";
            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@note", note);
            command.Parameters.AddWithValue("@id", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        // update user's xp
        public async static Task UpdateXp (string id, int xp)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = "UPDATE users SET xp = @xp  WHERE user_id = @id";
            using MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@xp", xp);
            command.Parameters.AddWithValue("@id", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }


    }


}
