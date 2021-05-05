﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
   public class User
    {
        // UserId, Username, Password, Email, Name, Balance
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }

       [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
