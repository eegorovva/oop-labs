using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.Admin;

public class UserScenarioProvider : IScenarioProvider
{
    private IUserRepository _userRepository;
    private ICurrentUserService _currentUser;

    public UserScenarioProvider(IUserRepository userRepository, ICurrentUserService currentUser)
    {
        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null || _currentUser.Role != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new UserScenario(_userRepository);
        return true;
    }
}