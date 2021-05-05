﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        //BetId, Amount, Prediction, DateTime, UserId, GameId
        [Key]
        public int BetId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        
        public Game Game { get; set; }
    }
}
