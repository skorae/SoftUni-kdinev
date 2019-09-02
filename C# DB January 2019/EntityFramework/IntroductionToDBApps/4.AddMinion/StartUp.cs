using MinionsDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AddMinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] arrMinion = Console.ReadLine().Split();
            string[] arrVillian = Console.ReadLine().Split();

            string minionName = arrMinion[1];
            int monionAge = int.Parse(arrMinion[2]);
            string minionTown = arrMinion[3];
            string villianName = arrVillian[1];

            string checkQuerry = string.Empty;
            string addQuerry = string.Empty;
            string scalarSql = string.Empty;
            string type = string.Empty;

            using (SqlConnection connection = new SqlConnection(Configuration.DataBaseConnection))
            {
                connection.Open();

                checkQuerry = @"SELECT Id FROM Towns WHERE Name = @townName";
                addQuerry = @"INSERT INTO Towns (Name) VALUES (@townName)";
                scalarSql = checkQuerry.Split().Last();
                type = "Town";

                int townId = ExecuteScalar(minionTown, checkQuerry, addQuerry, connection, scalarSql, type);

                addQuerry = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                AddMinionToDataBase(connection, addQuerry, minionName, monionAge, townId);

                checkQuerry = @"SELECT Id FROM Villains WHERE Name = @Name";
                addQuerry = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@Name, 4)";
                scalarSql = checkQuerry.Split().Last();
                type = "Villain";

                int villanId = ExecuteScalar(villianName, checkQuerry, addQuerry, connection, scalarSql, type);

                checkQuerry = @"SELECT Id FROM Minions WHERE Name = @Name";
                addQuerry = "";
                scalarSql = checkQuerry.Split().Last();
                int minionId = ExecuteScalar(minionName, checkQuerry, addQuerry, connection, scalarSql, type);

                addQuerry = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

                try
                {
                    AddToMappingTable(connection, addQuerry, minionId, villanId, villianName, minionName);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Already Exists In The Table!");
                }
            }
        }

        private static void AddToMappingTable(SqlConnection connection, string addQuerry, int minionId, int villanId, string villianName, string minionName)
        {
            using (SqlCommand command = new SqlCommand(addQuerry, connection))
            {
                command.Parameters.AddWithValue("@villainId", villanId);
                command.Parameters.AddWithValue("@minionId", minionId);

                command.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");
            }
        }

        private static void AddMinionToDataBase(SqlConnection connection, string addQuerry, string minionName, int monionAge, int townId)
        {
            using (SqlCommand command = new SqlCommand(addQuerry, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", monionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        private static int ExecuteScalar<T>(T scalarValue, string checkQuerry, string addQuerry, SqlConnection connection, string scalarSql, string type)
        {
            using (SqlCommand command = new SqlCommand(checkQuerry, connection))
            {
                command.Parameters.AddWithValue(scalarSql, scalarValue);

                int? id = GetId(command);

                switch (id)
                {
                    case null:
                        AddIntoDataBase(addQuerry, connection, scalarValue, scalarSql);
                        Console.WriteLine($"{type} {scalarValue} was added to the database.");
                        return (int)GetId(command);
                    default:
                        return (int)id;
                }
            }
        }

        private static void AddIntoDataBase<T>(string addQuerry, SqlConnection connection, T scalarValue, string scalarSql)
        {
            using (SqlCommand command = new SqlCommand(addQuerry, connection))
            {
                command.Parameters.AddWithValue(scalarSql, scalarValue);
                command.ExecuteNonQuery();
            }
        }

        private static int? GetId(SqlCommand sqlCommand)
        {
            return (int?)sqlCommand.ExecuteScalar();
        }
    }
}
