using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanceDbContext _context;

        public UserRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailOrUsernameAsync(string? email, string? username, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(username))
                throw new InvalidOperationException("User not found.");

            var normalizedEmail = email?.Trim().ToLowerInvariant();
            var normalizedUsername = username?.Trim().ToLowerInvariant();
            var user = await _context.Users.Where(x => x.Email == normalizedEmail || x.Username == normalizedUsername).ToListAsync();

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials user not found.");

            if (user?.Count > 1)
                throw new InvalidOperationException("Multiple users found with the same email or username.");

            return user?.FirstOrDefault();
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var normalized = email.Trim().ToLowerInvariant();
            return await _context.Users.AnyAsync(x => x.Email == normalized, cancellationToken);
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> AnyByEmailAndUsernameAsync(string email, string username, CancellationToken cancellationToken = default)
        {
            var normalizedEmail = email.Trim().ToLowerInvariant();
            var normalizedUsername = username.Trim().ToLowerInvariant();

            return await _context.Users.AnyAsync(x => x.Email == normalizedEmail || x.Username == normalizedUsername, cancellationToken);
        }
    }
}
