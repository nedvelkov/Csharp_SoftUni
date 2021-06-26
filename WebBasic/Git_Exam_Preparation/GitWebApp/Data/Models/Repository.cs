namespace GitWebApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   public class Repository
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; init; }

        [Required]
        public DateTime CreatedOn { get; init; }

        [Required]
        public bool IsPublic { get; init; }

        [MinLength(2)]
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Commit> Commits { get; set; }

    }
}
