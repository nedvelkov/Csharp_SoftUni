using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        /*
         *, , HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result)
         */

        public Game()
        {
            this.Bets = new HashSet<Bet>();
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int GameId { get; set; }
        public int HomeTeamId { get; set; }
       // [InverseProperty(nameof(Team.HomeGames))]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
     //   [InverseProperty(nameof(Team.AwayGames))]
        public Team AwayTeam { get; set; } 

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public string Result { get; set; } // not sure
        //?
        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }
        //?

        public ICollection<Bet> Bets { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

    }
}
