using Contracts;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class UserLogin : IScenario
{
    private IUserService _user;

    public UserLogin(IUserService userService)
    {
        if (userService is null)
        {
            throw new ArgumentException("service cannot be null");
        }

        _user = userService;
    }

    public string Name => "user login";

    public void Start()
    {
        long userId = AnsiConsole.Ask<long>("write your user id");
        long userPassword = AnsiConsole.Ask<long>("write your user password");
        LoginResult result = _user.LoginUser(userId, userPassword);

        string message = result switch
        {
            LoginResult.SuccessResult => "error: successful log",
            LoginResult.WrongPasswordResult => "error: wrong password",
            LoginResult.NotFoundResult => "error: user not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}