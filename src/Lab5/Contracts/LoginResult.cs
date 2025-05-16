namespace Contracts;

public abstract record LoginResult
{
    private LoginResult() { }

#pragma warning disable CA1034
    public sealed record SuccessResult : LoginResult;

    public sealed record WrongPasswordResult : LoginResult;

    public sealed record NotFoundResult : LoginResult;
#pragma warning restore CA1034
}