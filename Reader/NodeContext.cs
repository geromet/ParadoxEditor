using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class NodeContext : DbContext
    {
        public DbSet<InputFile> InputFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=input_files.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InputFile>()
                .HasOne(i => i.RootNode)
                .WithOne()
                .HasForeignKey<InputFile>(i => i.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Node>()
                .HasMany(n => n.Children)
                .WithOne()
                .HasForeignKey("ParentNodeId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
