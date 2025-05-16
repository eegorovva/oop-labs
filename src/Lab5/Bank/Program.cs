using Application.Extensions;
using Console;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

internal class Program
{
    public static void Main()
    {
        var collectionWithOperation = new ServiceCollection();

        collectionWithOperation
            .AddApplication()
            .AddInfrastructureDataAccess()
            .AddPresentationConsole();

        ServiceProvider provider = collectionWithOperation.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        Screnario scenarioRunner = scope.ServiceProvider
            .GetRequiredService<Screnario>();

        while (true)
        {
            scenarioRunner.Start();
            AnsiConsole.Clear();
        }
    }
}