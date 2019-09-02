using MinionsDB;
using System;
using System.Data.SqlClient;

namespace RemoveVillain
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();

                string villainName = GetVillainName(connection, villainId);

                int deletedMinions = DeleteMinions(connection, villainId);

                DeleteVillain(connection, villainName, villainId, deletedMinions);
            }
        }

        private static void DeleteVillain(SqlConnection connection, string villainName, int villainId, int deletedMinions)
        {
            string querry = @"DELETE FROM Villains
                                WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
            }
            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{deletedMinions} minions were released.");
        }

        private static int DeleteMinions(SqlConnection connection, int villainId)
        {
            string querry = @"DELETE FROM MinionsVillains 
                                WHERE VillainId = @villainId";

            int count = 0;

            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);

                count = command.ExecuteNonQuery();
            }

            return count;
        }

        private static string GetVillainName(SqlConnection connection, int villianId)
        {
            string querry = "SELECT Name FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                command.Parameters.AddWithValue("@villainId", villianId);

                string name = (string)command.ExecuteScalar();

                if (name == null)
                {
                    Console.WriteLine("No such villain was found.");
                    Environment.Exit(0);
                }

                return name;
            }
        }
    }
}
