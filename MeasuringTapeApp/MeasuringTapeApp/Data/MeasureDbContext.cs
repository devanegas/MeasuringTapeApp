using MeasuringTapeApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeasuringTapeApp.Data
{
    public class MeasureDbContext :DbContext
    {

        public MeasureDbContext(DbContextOptions<MeasureDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MeasuredObject> MeasuredObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasuredObject>().HasKey(m => m.Id);
            base.OnModelCreating(modelBuilder);
        }
        //private const string databaseName = "database2.db";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    String databasePath = "";
        //    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);

        //    // Specify that we will use sqlite and the path of the database here
        //    optionsBuilder.UseSqlite($"Filename={databasePath}");
        //}
    }
}

