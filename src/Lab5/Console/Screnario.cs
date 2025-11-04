using Spectre.Console;

namespace Console;

public class Screnario
{
    private IEnumerable<IScenarioProvider> _providers;

    public Screnario(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Start()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Start();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}