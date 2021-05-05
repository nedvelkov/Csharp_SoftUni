using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Engine
    {
        private Dictionary<string, Team> teams;
        private IRead read = new ReadConsole();
        private IWriter writer = new WriteConsole();
        public Engine()
        {
            this.teams = new Dictionary<string, Team>();
        }
        public void Run()
        {
            var input = read.ReadLine();
            if (input.ToLower().Equals("end")) Environment.Exit(0);
            var tokkens = input.Split(";");
            var command = tokkens[0];
            var name = tokkens[1];
            string playerName;
            int endurance;
            int sprint;
            int drible;
            int passing;
            int shooting;
            try
            {
                switch (command.ToLower())
                {
                    case "team":
                        var team = new Team(name);
                        this.teams.Add(name, team);
                        break;
                    case "add":
                        if (this.teams.ContainsKey(name) == false)
                        {
                            throw new ArgumentException($"Team {name} does not exist.");
                        }
                        playerName = tokkens[2];
                        endurance = int.Parse(tokkens[3]);
                        sprint = int.Parse(tokkens[4]);
                        drible = int.Parse(tokkens[5]);
                        passing = int.Parse(tokkens[6]);
                        shooting = int.Parse(tokkens[7]);
                        Player player = new Player(playerName, endurance, sprint, drible, passing, shooting);
                        this.teams[name].Add(player);
                        break;
                    case "remove":
                        if (this.teams.ContainsKey(name) == false)
                        {
                            throw new ArgumentException($"Team {name} does not exist.");
                        }
                        playerName = tokkens[2];
                        this.teams[name].Remove(playerName);
                        break;
                    case "rating":
                        if (this.teams.ContainsKey(name) == false)
                        {
                            throw new ArgumentException($"Team {name} does not exist.");
                        }
                        var currentTeam = this.teams[name];
                        writer.WriteLine($"{name} - {currentTeam.Rating}");
                        break;
                }
            }
            catch (Exception ex)
            {

                writer.WriteLine(ex.Message);
            }

        }

    }
}
