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
        public string Name { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public DateTime CreateAt { get; private set; }

        public User()
        {}

        public User(Guid? id, string email, string name, string username, string passwordHash)
        {
            Id = id ?? Guid.NewGuid();
            Email = email.Trim().ToLowerInvariant();
            Name = name?.Trim() ?? string.Empty;
            Username = username.Trim().ToLowerInvariant();
            PasswordHash = passwordHash;
            CreateAt = DateTime.UtcNow;
        }
        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
    }
}
