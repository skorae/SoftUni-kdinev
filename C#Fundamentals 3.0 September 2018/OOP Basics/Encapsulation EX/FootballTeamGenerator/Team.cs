using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        private double rating;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
            this.Rating = 0;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public List<Player> Players
        {
            get { return this.players; }
            private set { this.players = value; }
        }

        public double Rating
        {
            get { return this.rating; }
            private set { this.rating = value; }
        }

        internal void AddPlayer(Player player)
        {
            if (!this.Players.Any(x => x.Name == player.Name))
            {
                this.Players.Add(player);
            }
        }

        internal void Remove(string playerName)
        {
            if (!this.Players.Any(x => x.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            foreach (var p in this.Players)
            {
                if (p.Name == playerName)
                {
                    this.Players.Remove(p);
                    return;
                }
            }
        }

        internal void GetRatings(string teamName)
        {
            if (this.Players.Count != 0)
            {
                Console.WriteLine($"{this.Name} - {(int)Math.Round(this.Players.Average(x => x.SkillLevel))}");
                return;
            }
            Console.WriteLine($"{this.Name} - 0");

        }
    }
}
