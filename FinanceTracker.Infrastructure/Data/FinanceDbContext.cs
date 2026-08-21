using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options):base(options)
        {}

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<CreditCard> CreditCards => Set<CreditCard>();
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<Installment> Installments => Set<Installment>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
