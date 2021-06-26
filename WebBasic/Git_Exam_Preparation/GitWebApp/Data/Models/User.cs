namespace GitWebApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Username { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Password { get; init; }

        public ICollection<Repository> Repositories { get; set; }
        public ICollection<Commit> Commits { get; set; }

    }
}
