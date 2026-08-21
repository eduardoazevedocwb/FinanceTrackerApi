using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public DateTime CreateAt { get; private set; }

        public User()
        {}

        public User(string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email.Trim().ToLowerInvariant();
            PasswordHash = passwordHash;
            CreateAt = DateTime.UtcNow;
        }
        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
    }
}
