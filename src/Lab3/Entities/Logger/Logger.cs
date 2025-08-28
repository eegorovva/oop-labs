using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
public class Logger : ILogger
{
    private Collection<string> _logs;

    public Logger()
    {
        _logs = new Collection<string>();
    }

    public Collection<string> Logs => _logs;

    public virtual void Log(string message)
    {
        _logs.Add(message);
    }
}
