using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
public interface ILogger
{
    public Collection<string> Logs { get; }
    public void Log(string message);
}
