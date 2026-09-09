using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();
        public string Hash(User user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        public bool Verify(User user, string password, string passwordHash)
        {
            var result = _hasher.VerifyHashedPassword(user, passwordHash, password);
            return result != PasswordVerificationResult.Failed;
        }
    }
}
