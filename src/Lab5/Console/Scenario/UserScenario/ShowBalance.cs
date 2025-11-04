using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.User;

public class ShowBalance : IScenario
{
    private ICurrentUserService _currentUser;

    public ShowBalance(
        ICurrentUserService userService)
    {
        _currentUser = userService;
    }

    public string Name => "Show balance";

    public void Start()
    {
        if (_currentUser.User is null)
        {
            throw new ArgumentNullException();
        }

#pragma warning disable CA1305
        AnsiConsole.WriteLine(_currentUser.User.Balance);
#pragma warning restore CA1305
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}