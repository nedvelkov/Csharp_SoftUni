using System;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
  public  class Program
    {
       public static void Main()
        {
            var db = new HospitalContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
