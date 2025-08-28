using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
public interface IDisplayDriver
{
    public void RemoveMessage();
    public void ChooseColor(ConsoleColor color);
    public void ShowMessage(Message message);
}
