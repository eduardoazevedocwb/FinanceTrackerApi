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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasPrecision(18, 2);

            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired();

            builder.Property(e => e.PaymentMethod)
                .IsRequired();

            builder.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CreditCard)
                .WithMany()
                .HasForeignKey(e => e.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
