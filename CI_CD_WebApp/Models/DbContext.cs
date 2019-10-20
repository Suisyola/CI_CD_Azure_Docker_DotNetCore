using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CI_CD_WebApp.Models
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Notification> GetAllNotifications()
        {
            List<Notification> notifications = new List<Notification>();

            Console.WriteLine("Connection String is " + ConnectionString);

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from notification", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notifications.Add(new Notification()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Text = reader["Text"].ToString()
                        });
                    }
                }
            }
            return notifications;
        }
    }
}
