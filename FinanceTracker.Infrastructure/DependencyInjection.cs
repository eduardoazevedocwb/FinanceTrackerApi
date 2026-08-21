using FinanceTracker.Application.Application;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.Services;
using FinanceTracker.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, Expenserepository>();
            services.AddScoped<IInstallmentRepository, InstallmentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IDashboardService, DashboardService>();
            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInstallmentGenerator, InstallmentGenerator>();

            return services;
        }
    }
}
