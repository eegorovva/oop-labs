using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
public class ConsoleDisplayDriver : IDisplayDriver
{
    public void ChooseColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void RemoveMessage()
    {
        Console.Clear();
    }

    public void ShowMessage(Message message)
    {
        Console.WriteLine($"{message.Tittle}. {message.Text}");
    }
}
