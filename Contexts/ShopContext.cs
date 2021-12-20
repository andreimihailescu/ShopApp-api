using System;
using System.Collections.Generic;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Contexts
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public string DbPath { get; private set; }
        public ShopContext()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}ShopDatabase.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}