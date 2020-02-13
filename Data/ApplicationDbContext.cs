using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terminarz.Models;

namespace Terminarz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        { }
     //   public DbSet<Terminarz.Models.Task> Tasks { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Happening> Happenings { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Call>()
                .HasOne(p => p.Contact)
                .WithMany(b => b.Calls)
                .HasForeignKey(p => p.ContactID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Meeting>()
                .HasOne(p => p.Contact)
                .WithMany(b => b.Meetings)
                .HasForeignKey(p => p.ContactID);

        }
    }
}
