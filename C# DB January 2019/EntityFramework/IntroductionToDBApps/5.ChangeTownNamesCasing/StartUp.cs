using MinionsDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ChangeTownNamesCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();
              

               int updated = Update(connection, countryName);

                switch (updated)
                {
                    case 0:
                        Console.WriteLine("No town names were affected.");
                        return;
                    default:
                        Console.WriteLine($"{updated} town names were affected.");
                        break;
                }
                
               string[] arr = Print(connection, countryName).ToArray();

                Console.WriteLine($"[{string.Join(", ", arr)}]");
            }
        }

        private static List<string> Print(SqlConnection connection,string countryName)
        {
            List<string> result = new List<string>();

            string querry = @" SELECT t.Name 
                             FROM Towns as t
                             JOIN Countries AS c ON c.Id = t.CountryCode
                            WHERE c.Name = @countryName";

            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((string)reader[0]);
                    }
                }
            }

            return result;
        }

        private static int Update(SqlConnection connection, string countryName)
        {
            string querry = @"UPDATE Towns
                               SET Name = UPPER(Name)
                             WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);
                return command.ExecuteNonQuery();
            }
        }
    }
}
