using Console.Scenarios.Admin;
using Console.Scenarios.Login;
using Console.Scenarios.QuitProgram;
using Console.Scenarios.User;
using Microsoft.Extensions.DependencyInjection;

namespace Console;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<Screnario>();

        collection.AddScoped<IScenarioProvider, UserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginProvider>();
        collection.AddScoped<IScenarioProvider, LogoutProvider>();
        collection.AddScoped<IScenarioProvider, UserLoginProvider>();
        collection.AddScoped<IScenarioProvider, QuitProgramProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyProvider>();
        collection.AddScoped<IScenarioProvider, RemoveMoneyProvider>();
        collection.AddScoped<IScenarioProvider, ShowBalanceProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryProvider>();

        return collection;
    }
}