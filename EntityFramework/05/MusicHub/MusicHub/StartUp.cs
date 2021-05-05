namespace MusicHub
{
    using MusicHub.Data;
   public class StartUp
    {
      public  static void Main()
        {
            var db = new MusicHubDbContext ();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
