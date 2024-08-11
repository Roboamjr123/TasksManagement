using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataLibrary.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Projects> Project { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<SubTasks> SubTask { get; set; }
        public DbSet<SubDetails> SubDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>()
           .HasMany(p => p.Task)
           .WithOne(t => t.Project)
           .HasForeignKey(t => t.Project_Id);

            modelBuilder.Entity<Tasks>()
                .HasMany(t => t.SubTask)
                .WithOne(st => st.Task)
                .HasForeignKey(st => st.Task_Id);

            modelBuilder.Entity<SubTasks>()
                .HasMany(st => st.SubDetail)
                .WithOne(sd => sd.SubTask)
                .HasForeignKey(sd => sd.SubT_Id);

        }

    }
}
     
    
