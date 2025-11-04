namespace Console.Scenarios.QuitProgram;

public class QuitProgram : IScenario
{
    public string Name => "quit of program";

    public void Start()
    {
        Environment.Exit(0);
    }
}