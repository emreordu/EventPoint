using EventPoint.DataAccess.IdentityServer.Models;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<EventFavorite> EventFavorites { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            //entity framework modified/created date update
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventUser>().HasKey(eu => new {eu.EventId,eu.UserId});

            modelBuilder.Entity<EventUser>()
                .HasOne(e => e.Event)
                .WithMany(eu => eu.EventUsers).
                HasForeignKey(ei => ei.EventId);

            modelBuilder.Entity<EventUser>()
                .HasOne(u => u.User)
                .WithMany(ue => ue.UserEvents).
                HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<EventFavorite>().HasKey(ef => new {ef.EventId,ef.UserId});

            modelBuilder.Entity<EventFavorite>()
               .HasOne(e => e.Event)
               .WithMany(ef => ef.EventFavorited).
               HasForeignKey(ei => ei.EventId);

            modelBuilder.Entity<EventFavorite>()
                .HasOne(u => u.User)
                .WithMany(fe => fe.FavoritedEvents).
                HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "International WebSummIT",
                    Description = "descriptions will be added",
                    ParticipantLimit = 100,
                    EventDate = DateTime.Now.AddDays(10),
                    CreatedDate = DateTime.Now,
                },
                new Event
                {
                    Id = 2,
                    Name = "Speaking Club Event",
                    Description = "descriptions will be added",
                    ParticipantLimit = 25,
                    EventDate = DateTime.Now.AddDays(3),
                    CreatedDate = DateTime.Now,
                },
                new Event
                {
                    Id = 3,
                    Name = "İstanbul Shopping Fest",
                    Description = "descriptions will be added",
                    ParticipantLimit = 3000,
                    EventDate = DateTime.Now.AddDays(25),
                    CreatedDate = DateTime.Now,
                });
        }
    }
}