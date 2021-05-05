using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        //PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int? TeamId { get; set; } // if player is free agent

        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

    }
}
