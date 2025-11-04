using Abstractions;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.User;

public class AddMoney : IScenario
{
    private ICurrentUserService _user;
    private IUserRepository _repository;

    public AddMoney(ICurrentUserService user, IUserRepository repository)
    {
        if (user is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        if (repository is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _user = user;
        _repository = repository;
    }

    public string Name => "add money";

    public void Start()
    {
        decimal count = AnsiConsole.Ask<decimal>("write count");

        if (_user.User is null)
        {
            throw new ArgumentNullException();
        }

        if (count < 0)
        {
            AnsiConsole.WriteLine("amount can not be below zero");
        }
        else
        {
            _repository.AddMoney(_user.User.Id, count);
        }

        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}