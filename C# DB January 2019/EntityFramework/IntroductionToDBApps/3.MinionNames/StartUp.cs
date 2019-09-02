using MinionsDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();

                string querry = @"SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(querry, connection))
                {
                    command.Parameters.AddWithValue("@Id", n);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string villanName = (string)reader[0];

                            if (villanName == null)
                            {
                                Console.WriteLine($"No villain with ID {n} exists in the database.");
                                return;
                            }

                            Console.WriteLine($"Villain: {villanName}");
                        }
                    }
                }

                querry = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(querry, connection))
                {
                    command.Parameters.AddWithValue("@Id", n);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long rowNum = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];

                            Console.WriteLine($"{rowNum}. {name} {age}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }

            }
        }
    }
}
