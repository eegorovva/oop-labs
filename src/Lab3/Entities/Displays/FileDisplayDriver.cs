using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
public class FileDisplayDriver : IDisplayDriver
{
    private string _pathToFile;

    public FileDisplayDriver(string pathToFile)
    {
        if (pathToFile is null)
        {
            throw new ArgumentException("pathToFile cannot be null:", nameof(pathToFile));
        }

        _pathToFile = pathToFile;
    }

    public void RemoveMessage()
    {
        File.WriteAllText(_pathToFile, string.Empty);
    }

    public void ChooseColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void ShowMessage(Message message)
    {
        File.AppendAllText(_pathToFile, message.Tittle + " " + message.Text);
    }
}
