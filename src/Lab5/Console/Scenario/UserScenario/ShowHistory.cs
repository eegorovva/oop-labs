using Abstractions;
using Contracts.Users;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.User;

public class ShowHistory : IScenario
{
    private IOperationRepository _operationRepository;
    private ICurrentUserService _currentUser;

    public ShowHistory(IOperationRepository operationRepository, ICurrentUserService userService)
    {
        if (operationRepository is null)
        {
            throw new ArgumentException("repository cannot be null");
        }

        if (userService is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _operationRepository = operationRepository;
        _currentUser = userService;
    }

    public string Name => "Show history";

    public void Start()
    {
        if (_currentUser.User is null)
        {
            throw new ArgumentNullException();
        }

        foreach (Operation operation in _operationRepository.GetOperationsByUserId(_currentUser.User.Id))
        {
            AnsiConsole.WriteLine(operation.ToString());
        }

        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}