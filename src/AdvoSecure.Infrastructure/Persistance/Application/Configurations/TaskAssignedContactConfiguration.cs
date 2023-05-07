using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class TaskAssignedContactConfiguration : IEntityTypeConfiguration<TaskAssignedContact>
    {
        public void Configure(EntityTypeBuilder<TaskAssignedContact> builder)
        {
            builder.HasKey(tc => new { tc.ContactId, tc.TaskId });

            builder.HasOne<Contact>(tc => tc.Contact)
                    .WithMany(c => c.TaskAssignedContacts)
                    .HasForeignKey(tc => tc.ContactId);


            builder.HasOne<InnerTask>(tc => tc.Task)
                    .WithMany(t => t.TaskAssignedContacts)
                    .HasForeignKey(tc => tc.TaskId);
        }
    }
}
