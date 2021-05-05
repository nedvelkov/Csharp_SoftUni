using System;
using P01_StudentSystem.Data;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem
{
    public class StatUp
    {
        static void Main()
        {
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
           // db.Database.EnsureCreated();
        }
    }
}
