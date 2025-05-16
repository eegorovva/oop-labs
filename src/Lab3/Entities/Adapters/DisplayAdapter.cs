using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Adapters;
public class DisplayAdapter
{
    private Display _display;

    public DisplayAdapter(Display display)
    {
        if (display is null)
        {
            throw new ArgumentException("display cannot be null: ", nameof(display));
        }

        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        _display.ReceiveMessage(message);
    }
}
