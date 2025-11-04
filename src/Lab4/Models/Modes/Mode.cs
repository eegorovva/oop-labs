using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Mode;
public class Mode
{
    private Collection<string> _mode;

    public Mode()
    {
        _mode = new Collection<string>() { "local", "console" };
    }

    public Collection<string> Modes => _mode;

    public void AddFlag(string mode)
    {
        _mode.Add(mode);
    }
}
