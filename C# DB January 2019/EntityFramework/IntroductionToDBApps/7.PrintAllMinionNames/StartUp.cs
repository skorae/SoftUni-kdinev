using MinionsDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintAllMinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();

                List<string> minionsNames = GetAllNames(connection);

                PrintNames(minionsNames);
            }
        }

        private static void PrintNames(List<string> minionsNames)
        {
            int lenght = minionsNames.Count % 2;

            switch (lenght)
            {
                case 1:
                    for (int i = 0; i < minionsNames.Count / 2; i++)
                    {
                        Console.WriteLine(minionsNames[i]);
                        Console.WriteLine(minionsNames[minionsNames.Count - 1 - i]);
                    }
                    Console.WriteLine(minionsNames[minionsNames.Count / 2]);
                    break;
                default:
                    for (int i = 0; i < minionsNames.Count / 2; i++)
                    {
                        Console.WriteLine(minionsNames[i]);
                        Console.WriteLine(minionsNames[minionsNames.Count - 1 - i]);
                    }
                    break;
            }
        }

        private static List<string> GetAllNames(SqlConnection connection)
        {
            List<string> names = new List<string>();
            string querry = @"SELECT Name FROM Minions";

            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add((string)reader[0]);
                    }
                }
            }

            return names;
        }
    }
}
