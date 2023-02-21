using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPoint.DataAccess.Configurations
{
    public class EventFavoriteConfiguration : IEntityTypeConfiguration<EventFavorite>
    {
        public void Configure(EntityTypeBuilder<EventFavorite> builder)
        {
            builder.HasKey(ef => new { ef.EventId, ef.UserId });

            builder
               .HasOne(e => e.Event)
               .WithMany(ef => ef.EventFavorited).
               HasForeignKey(ei => ei.EventId);

            builder
                .HasOne(u => u.User)
                .WithMany(fe => fe.FavoritedEvents).
                HasForeignKey(ui => ui.UserId);
        }
    }
}