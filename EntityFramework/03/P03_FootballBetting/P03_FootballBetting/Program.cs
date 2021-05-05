using System;
using P03_FootballBetting.Data;
namespace P03_FootballBetting
{
   public class Program
    {
      public  static void Main()
        {
            var db =new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            //75/100 from Judje
        }
    }
}
