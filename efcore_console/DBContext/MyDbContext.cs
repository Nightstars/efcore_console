using efcore_console.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace efcore_console.DBContext
{
    class MyDbContext: DbContext
    {
        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<TestTableDetail> TestTableDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=Test;Server=192.168.2.114,50000;User ID = sa; Password = Ihavenoidea@0;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var assembly = Assembly.GetExecutingAssembly();
        //    var types = assembly?.GetTypes();
        //    var list = types?.Where(x => x.IsClass && !x.IsGenericType && !x.IsAbstract && x.GetInterfaces().Any(m => m.IsAssignableFrom(typeof(EntityBase)))).ToList();
        //    if (list.Any())
        //        list.ForEach(x =>
        //        {
        //            if (modelBuilder.Model.FindEntityType(x) == null)
        //                modelBuilder.Model.AddEntityType(x);
        //        });

        //    base.OnModelCreating(modelBuilder); 
        //}
    }
}
