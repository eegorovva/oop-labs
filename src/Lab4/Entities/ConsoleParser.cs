using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Mode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;
public class ConsoleParser
{
    private Flags _flag;
    private Mode _modes;
    private ICommandHandler? _handler;
    private IFileSystem? _fileSystem;
    private bool _isConnected;
    private bool _isDisconected;

    public ConsoleParser()
    {
        _flag = new Flags();
        _modes = new Mode();
        _fileSystem = null;
        _isConnected = false;
        _isDisconected = true;
        _handler = null;
    }

    public IFileSystem? FileSystem => _fileSystem;

    public void SetHanlder(ICommandHandler handler)
    {
        _handler = handler;
    }

    public void Parse()
    {
        string? command = Console.ReadLine();

        if (command != null)
        {
            string[] splitCommand = command.Split(' ');

            if (splitCommand[0] == "connect" && splitCommand.Length >= 3)
            {
                if (splitCommand.Contains("-m") && splitCommand.Contains("local"))
                {
                    _fileSystem = new LocalFileSystem(new DisplayConsoleFileSystem());
                    _isConnected = true;
                    _isDisconected = false;

                    do
                    {
                        string? commandHandler = Console.ReadLine();

                        if (commandHandler != null)
                        {
                            string[] splitCommandHandler = commandHandler.Split(' ');

                            if (splitCommandHandler[0] != "disconnect" && _handler != null)
                            {
                                _handler.Execute(commandHandler.Split(' '), _fileSystem);
                            }
                            else
                            {
                                _isConnected = false;
                                _isDisconected = true;
                            }
                        }
                    }
                    while (_isDisconected == false && _isConnected == true);
                }
            }
        }
    }
}