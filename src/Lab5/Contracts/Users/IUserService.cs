namespace Contracts.Users;

public interface IUserService
{
    LoginResult LoginUser(long id, long password);
    LoginResult LoginAdmin(string adminName, string password);
    void LogoutAccount();
}