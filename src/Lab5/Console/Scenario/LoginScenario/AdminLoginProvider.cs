using System.Diagnostics.CodeAnalysis;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.Login;

public class AdminLoginProvider : IScenarioProvider
{
    private IUserService _service;
    private ICurrentUserService _currentUser;

    public AdminLoginProvider(IUserService service, ICurrentUserService currentUser)
    {
        if (service is null)
        {
            throw new ArgumentException("service cannot be null");
        }

        if (currentUser is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null && _currentUser.Role != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLogin(_service);
        return true;
    }
}