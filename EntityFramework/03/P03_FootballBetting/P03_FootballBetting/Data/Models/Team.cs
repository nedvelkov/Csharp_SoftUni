﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.AwayGames = new HashSet<Game>();
            this.HomeGames = new HashSet<Game>();
        }
        [Key]
        public int TeamId { get; set; }
        [MaxLength(80)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string LogoUrl { get; set; }
        [Column(TypeName = ("char(3)"))]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

      //  [InverseProperty(nameof(Color.PrimaryKitTeams))]
        public Color PrimaryKitColor { get; set; }


        public int SecondaryKitColorId { get; set; }

     //   [InverseProperty(nameof(Color.SecondaryKitTeams))]
        
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Game> HomeGames { get; set; }
        public ICollection<Game> AwayGames { get; set; }



    }
}
