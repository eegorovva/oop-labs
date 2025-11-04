using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.User;

public class AddMoneyProvider : IScenarioProvider
{
    private ICurrentUserService _currentUser;
    private IUserRepository _userRepository;

    public AddMoneyProvider(IUserRepository userRepository, ICurrentUserService currentUser)
    {
        if (userRepository is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        if (currentUser is null)
        {
            throw new ArgumentException("currentUser cannot be null ");
        }

        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.Role != UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new AddMoney(_currentUser, _userRepository);
        return true;
    }
}