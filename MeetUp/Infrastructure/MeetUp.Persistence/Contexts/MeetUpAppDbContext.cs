using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Abstractions;
using MeetUp.Domain.Entities;
using MeetUp.Domain.Entities.Identity;
using MeetUp.Persistence.Inceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MeetUp.Persistence.Contexts
{
    public class MeetUpAppDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public MeetUpAppDbContext(DbContextOptions<MeetUpAppDbContext> opt) : base(opt)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new EFCommandInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AttendedEvent>()
                .HasKey(ae => new { ae.EventId, ae.ApplicationUserId });
            modelBuilder.Entity<AttendedEvent>()
                .HasOne(ae => ae.Event)
                .WithMany(e => e.AttendedEvents)
                .HasForeignKey(ae => ae.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AttendedEvent>()
                .HasOne(ae => ae.ApplicationUser)
                .WithMany(u => u.AttendedEvents)
                .HasForeignKey(ae => ae.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteEvent>()
                .HasKey(fe => new { fe.EventId, fe.ApplicationUserId });
            modelBuilder.Entity<FavoriteEvent>()
                .HasOne(fe => fe.Event)
                .WithMany(e => e.FavoriteEvents)
                .HasForeignKey(ae => ae.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FavoriteEvent>()
                .HasOne(fe => fe.ApplicationUser)
                .WithMany(u => u.FavoriteEvents)
                .HasForeignKey(fe => fe.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
