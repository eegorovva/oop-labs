using System.Diagnostics.CodeAnalysis;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.User;

public class ShowBalanceProvider : IScenarioProvider
{
    private ICurrentUserService _currentUser;

    public ShowBalanceProvider(
        ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.Role != UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowBalance(_currentUser);
        return true;
    }
}