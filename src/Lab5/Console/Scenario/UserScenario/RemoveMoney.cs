using Abstractions;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.User;

public class RemoveMoney : IScenario
{
    private ICurrentUserService _userService;
    private IUserRepository _userRepository;

    public RemoveMoney(ICurrentUserService userService, IUserRepository userRepository)
    {
        if (userService is null)
        {
            throw new ArgumentException("user service cannot be null");
        }

        if (userRepository is null)
        {
            throw new ArgumentException("user service cannot be null");
        }

        _userService = userService;
        _userRepository = userRepository;
    }

    public string Name => "remove money";

    public void Start()
    {
        decimal amount = AnsiConsole.Ask<decimal>("write amount");

        if (_userService.User is null)
        {
            throw new ArgumentNullException();
        }

        if (amount > 0)
        {
            AnsiConsole.WriteLine("Amount can not be above zero");
        }
        else if (_userService.User.Balance < amount)
        {
            AnsiConsole.WriteLine("Balance can not be below zero");
        }
        else
        {
            _userRepository.AddMoney(_userService.User.Id, amount);
        }

        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}