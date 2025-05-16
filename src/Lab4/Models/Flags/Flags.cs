using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Flags;
public class Flags
{
    private Collection<string> _flags;

    public Flags()
    {
        _flags = new Collection<string>() { "-m", "-d" };
    }

    public Collection<string> FlagsforConsole => _flags;

    public void AddFlag(string flag)
    {
        _flags.Add(flag);
    }
}
