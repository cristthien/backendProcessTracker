using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTO;

namespace DAT
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Board> boards { get; set; }
        public DbSet<Viewer> viewers { get; set; }

        private const string connectionString = @"Data Source=DESKTOP-4TBCLIN;Initial Catalog=ProcessTracker;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Viewer>()
             .HasKey(v => new { v.userID, v.boardID });

        }


    }
}
