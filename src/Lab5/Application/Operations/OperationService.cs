using Abstractions;
using Contracts.Operations;
using Models.Operations;

namespace Application.Operations;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _repository;

    public OperationService(IOperationRepository repository)
    {
        if (repository is null)
        {
            throw new ArgumentException("repositoru cannot be null");
        }

        _repository = repository;
    }

    public IEnumerable<Operation> GetOperationsByUserId(long userId)
    {
        return _repository.GetOperationsByUserId(userId);
    }
}