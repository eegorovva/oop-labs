using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
public class Display
{
    private IDisplayDriver _displayDriver;
    private Message _message;

    public Display(Message message, IDisplayDriver driver)
    {
        if (message is null)
        {
            throw new ArgumentException("message cannot be null:", nameof(message));
        }

        if (driver is null)
        {
            throw new ArgumentException("driver cannot be null:", nameof(driver));
        }

        _message = message;
        _displayDriver = driver;
    }

    public void ReceiveMessage(Message message)
    {
        _message = message;
    }

    public void ShowMessage(ConsoleColor color)
    {
        _displayDriver.RemoveMessage();

        _displayDriver.ChooseColor(color);

        _displayDriver.ShowMessage(_message);
    }
}
