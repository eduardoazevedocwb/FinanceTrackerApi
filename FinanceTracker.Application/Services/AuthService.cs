using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
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

        public AuthService(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator, PasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponse> RegisterAsync(UserRegisterCommand request, CancellationToken cancellationToken = default)
        {
            if (await _userRepository.AnyByEmailAndUsernameAsync(request.Email, request.Username, cancellationToken))
                throw new Exception("Email or username already in use.");

            var user = new User(request.Email, request.Name, request.Username, string.Empty);
            var hash = _passwordHasher.HashPassword(user, request.Password);
            
            user.UpdatePasswordHash(hash);

            await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var (token, expiresAt) = _tokenGenerator.GenerateToken(user);

            return new AuthResponse(token, expiresAt, new UserResponse(user.Id, user.Name, user.Username, user.Email));
        }

        public async Task<AuthResponse?> LoginAsync(LoginCommand request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailOrUsernameAsync(request.Email, request.Username, cancellationToken);
            if (user is null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var verification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (verification == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }

            var (token, expiresAt) = _tokenGenerator.GenerateToken(user);

            return new AuthResponse(token, expiresAt, new UserResponse(user.Id, user.Name, user.Username, user.Email));
        }
    }
}
