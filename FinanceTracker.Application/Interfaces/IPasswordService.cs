using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Interfaces
{
    public interface IPasswordService
    {
        string Hash(User user, string password);
        bool Verify(User user, string password, string passwordHash);
    }
}