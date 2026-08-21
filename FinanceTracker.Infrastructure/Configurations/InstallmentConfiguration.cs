using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Configurations
{
    public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.ToTable("Installments");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Amount)
                .HasPrecision(18, 2);

            builder.HasOne(i => i.Expense)
                .WithMany()
                .HasForeignKey(i => i.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.ExpenseId, x.Number })
                .IsUnique();
        }
    }
}
