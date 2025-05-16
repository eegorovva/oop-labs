using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.Login;

public class LogoutProvider : IScenarioProvider
{
    private IUserService _currentUser;

    public LogoutProvider(IUserService currentUser)
    {
        if (currentUser is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new Logout(_currentUser);
        return true;
    }
}