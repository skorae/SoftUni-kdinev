using MinionsDB;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace IncreaseAgeStoredProcedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();

                AddStoredProcedure(connection);

                ExecuteProcedure(connection, minionId);

                PrintMinions(connection, minionId);
            }
        }

        private static void PrintMinions(SqlConnection connection, int minionId)
        {
            string querry = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(querry,connection))
            {
                command.Parameters.AddWithValue("@Id", minionId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }

        private static void ExecuteProcedure(SqlConnection connection, int minionId)
        {
            string querry = @"EXEC usp_GetOlder @Id";

            using (SqlCommand command = new SqlCommand(querry,connection))
            {
                command.Parameters.AddWithValue("@Id", minionId);
                command.ExecuteNonQuery();
            }
        }

        private static void AddStoredProcedure(SqlConnection connection)
        {
            string querry = @"CREATE PROC usp_GetOlder @id INT
                            AS
                            UPDATE Minions
                               SET Age += 1
                             WHERE Id = @id";

            using (SqlCommand command = new SqlCommand(querry,connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}
