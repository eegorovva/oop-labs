using Abstractions;
using Contracts;
using Contracts.Users;
using Models.Users;

namespace Application.Users;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private CurrentUserManager _currentUser;

    public UserService(IUserRepository userRepository, CurrentUserManager currentUser)
    {
        if (userRepository is null)
        {
            throw new ArgumentException("repositoru cannot be null");
        }

        if (currentUser is null)
        {
            throw new ArgumentException("repositoru cannot be null");
        }

        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public LoginResult LoginUser(long id, long password)
    {
        User? currentuUser = _userRepository.FindUserID(id);

        if (currentuUser is null)
        {
            _currentUser.User = null;
            _currentUser.Role = UserRole.Unknown;

            return new LoginResult.NotFoundResult();
        }

        if (currentuUser.Password != password)
        {
            _currentUser.User = null;
            _currentUser.Role = UserRole.Unknown;

            return new LoginResult.WrongPasswordResult();
        }

        _currentUser.User = currentuUser;
        _currentUser.Role = UserRole.User;

        return new LoginResult.SuccessResult();
    }

    public LoginResult LoginAdmin(string adminName, string password)
    {
        switch (adminName)
        {
            case "admin":
            {
                switch (password)
                {
                    case "123456":
                    {
                                _currentUser.Role = UserRole.Admin;

                                return new LoginResult.SuccessResult();
                    }

                    default:
                    {
                                _currentUser.Role = UserRole.Unknown;

                                return new LoginResult.WrongPasswordResult();
                    }
                }
            }

            default:
            {
                    _currentUser.Role = UserRole.Unknown;
                    return new LoginResult.NotFoundResult();
            }
        }
    }

    public void LogoutAccount()
    {
        _currentUser.User = null;
        _currentUser.Role = UserRole.Unknown;
    }
}