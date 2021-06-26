namespace GitWebApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Commit
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }

        [Required]
        public DateTime CreatedOn { get; init; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
