using MinionsDB;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace IncreaseMinionAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();

                IncrementChanges(connection, minionIds);

                PrintMinions(connection);
            }
        }

        private static void PrintMinions(SqlConnection connection)
        {
            string querry = @"SELECT Name, Age FROM Minions";

            using (SqlCommand command = new SqlCommand(querry,connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} {age}");
                    }
                }
            }
        }

        private static void IncrementChanges(SqlConnection connection, int[] minionIds)
        {
            string querry = @" UPDATE Minions
                                 SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                               WHERE Id = @Id";

            foreach (int id in minionIds)
            {
                using (SqlCommand command = new SqlCommand(querry,connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
