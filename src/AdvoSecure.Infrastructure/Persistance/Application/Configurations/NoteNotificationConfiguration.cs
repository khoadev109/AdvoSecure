using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class NoteNotificationConfiguration : IEntityTypeConfiguration<NoteNotification>
    {
        public void Configure(EntityTypeBuilder<NoteNotification> builder)
        {
            builder.HasKey(nn => new { nn.ContactId, nn.NoteId });

            builder.HasOne<Contact>(nn => nn.Contact)
                    .WithMany(c => c.NoteNotifications)
                    .HasForeignKey(nn => nn.ContactId);


            builder.HasOne<Note>(nn => nn.Note)
                    .WithMany(n => n.NoteNotifications)
                    .HasForeignKey(nn => nn.NoteId);
        }
    }
}
