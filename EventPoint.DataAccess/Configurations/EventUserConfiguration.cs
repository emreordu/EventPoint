using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPoint.DataAccess.Configurations
{
    public class EventUserConfiguration : IEntityTypeConfiguration<EventUser>
    {
        public void Configure(EntityTypeBuilder<EventUser> builder)
        {
            builder.HasKey(eu => new { eu.EventId, eu.UserId });

            builder
                 .HasOne(e => e.Event)
                 .WithMany(eu => eu.EventUsers).
                 HasForeignKey(ei => ei.EventId);

            builder
                .HasOne(u => u.User)
                .WithMany(ue => ue.UserEvents).
                HasForeignKey(ui => ui.UserId);
        }
    }
}