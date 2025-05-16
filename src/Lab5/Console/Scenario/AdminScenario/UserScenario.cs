using Abstractions;
using Spectre.Console;

namespace Console.Scenarios.Admin;

public class UserScenario : IScenario
{
    private readonly IUserRepository _userRepository;

    public UserScenario(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string Name => "add users";

    public void Start()
    {
        long userID = AnsiConsole.Ask<long>("Write user id...");
        long password = AnsiConsole.Ask<long>("Write user password..");

        if (_userRepository.FindUserID(userID) is not null)
        {
            AnsiConsole.WriteLine("you cannot add the same user");
        }
        else
        {
            _userRepository.InsertUser(userID, password);
        }

        AnsiConsole.Ask<string>("ok");
        AnsiConsole.Clear();
    }
}