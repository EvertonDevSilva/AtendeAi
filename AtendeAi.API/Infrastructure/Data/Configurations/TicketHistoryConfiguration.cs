using AtendeAi.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendeAi.API.Infrastructure.Data.Configurations
{
    public class TicketHistoryConfiguration : IEntityTypeConfiguration<TicketHistory>
    {
        public void Configure(EntityTypeBuilder<TicketHistory> builder)
        {
            builder.ToTable("TicketHistories");

            builder.HasOne(th => th.Ticket)
                .WithMany()
                .HasForeignKey(th => th.TicketId);

            builder.HasOne(th => th.Employee)
                    .WithMany()
                    .HasForeignKey(th => th.EmployeeId);

            builder.HasOne(th => th.CurrentDepartment)
                    .WithMany()
                    .HasForeignKey(th => th.CurrentDepartmentId);

            builder.Property(t => t.TicketId).IsRequired();
            builder.Property(e => e.EmployeeId).IsRequired();
            builder.Property(cd => cd.CurrentDepartmentId).IsRequired();
            builder.Property(ca=> ca.CreatedAt).IsRequired();
            builder.Property(ua => ua.UpdatedAt).IsRequired();
            builder.Property(s => s.Status).IsRequired();
        }
    }
}
