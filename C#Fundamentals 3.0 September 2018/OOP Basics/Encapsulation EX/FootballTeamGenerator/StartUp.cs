using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (command != "END")
            {
                string[] arr = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string teamName = arr[1];
                    switch (arr[0])
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(team);
                            break;
                        case "Add":
                            string playerName = arr[2];
                            double endurance = double.Parse(arr[3]);
                            double sprint = double.Parse(arr[4]);
                            double dribble = double.Parse(arr[5]);
                            double passing = double.Parse(arr[6]);
                            double shooting = double.Parse(arr[7]);

                            if (!teams.Any(x => x.Name == teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            team = teams.FirstOrDefault(x => x.Name == teamName);
                            Player player = new Player(playerName, new Stats(endurance, sprint, dribble, passing, shooting));
                            team.AddPlayer(player);
                            break;
                        case "Remove":
                            playerName = arr[2];

                            if (!teams.Any(x => x.Name == teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            team = teams.FirstOrDefault(x => x.Name == teamName);
                            team.Remove(playerName);
                            break;
                        case "Rating":
                            if (!teams.Any(x => x.Name == teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            team = teams.FirstOrDefault(x => x.Name == teamName);
                            team.GetRatings(teamName);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
