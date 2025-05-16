using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.User;

public class ShowHistoryProvider : IScenarioProvider
{
    private ICurrentUserService _currentUser;
    private IOperationRepository _operationRepository;

    public ShowHistoryProvider(IOperationRepository operationRepository, ICurrentUserService currentUser)
    {
        if (operationRepository is null)
        {
            throw new ArgumentException("repository cannot be null");
        }

        if (currentUser is null)
        {
            throw new ArgumentException("user cannot be null");
        }

        _operationRepository = operationRepository;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.Role != UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowHistory(_operationRepository, _currentUser);
        return true;
    }
}