using Contracts;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class AdminLogin : IScenario
{
    private IUserService _userService;

    public AdminLogin(IUserService userService)
    {
        if (userService is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _userService = userService;
    }

    public string Name => "admin login";

    public void Start()
    {
        string adminName = AnsiConsole.Ask<string>("write admin name");
        string password = AnsiConsole.Ask<string>("write admin password");
        LoginResult result = _userService.LoginAdmin(adminName, password);

        string message = result switch
        {
            LoginResult.SuccessResult => "successful login",
            LoginResult.WrongPasswordResult => "wrong password",
            LoginResult.NotFoundResult => "admin doesn't exist",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}