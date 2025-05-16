using Models.Users;

namespace Abstractions;

public interface IUserRepository
{
    User? FindUserID(long id);
    void InsertUser(long id, long pincode);
    void AddMoney(long id, decimal value);
    void RemoveMoney(long id, decimal value);
}