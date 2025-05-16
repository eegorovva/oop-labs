using System.Diagnostics.CodeAnalysis;

namespace Console.Scenarios.QuitProgram;

public class QuitProgramProvider : IScenarioProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new QuitProgram();
        return true;
    }
}