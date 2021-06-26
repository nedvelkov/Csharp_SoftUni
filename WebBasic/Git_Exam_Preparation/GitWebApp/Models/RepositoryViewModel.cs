namespace GitWebApp.Models
{
    public class RepositoryViewModel
    {
        public string Name { get; init; }
        public string Owner { get; init; }
        public string CreatedOn { get; init; }
        public int CommitsCount { get; set; }
    }
}
