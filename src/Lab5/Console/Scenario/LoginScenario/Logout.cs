using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class Logout : IScenario
{
    private IUserService _userService;

    public Logout(IUserService userService)
    {
        if (userService is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _userService = userService;
    }

    public string Name => "logout account";

    public void Start()
    {
        _userService.LogoutAccount();
        AnsiConsole.Ask<string>("Ok");
    }
}