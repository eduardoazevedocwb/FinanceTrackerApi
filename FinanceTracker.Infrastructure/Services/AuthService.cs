using FinanceTracker.Application.DTOs;
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
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            
            if (existing is not null)
            {
                throw new Exception("User with this email already exists.");
            }

            var user = new User(request.Email, string.Empty);
            var hash = _passwordHasher.HashPassword(user, request.Password);
            user.UpdatePasswordHash(hash);

            await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var (token, expiresAt) = _tokenGenerator.GenerateToken(user);

            return new AuthResponse(token, expiresAt,user.Email);
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (user is null)
            {
                throw new Exception("User not found.");
            }

            var verification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (verification == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password.");
            }

            var (token, expiresAt) = _tokenGenerator.GenerateToken(user);

            return new AuthResponse(token, expiresAt, user.Email);
        }
    }
}
