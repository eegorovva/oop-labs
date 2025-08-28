using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
using Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
public class DisplayAddressee : IAddressee
{
    private DisplayAdapter _display;
    private ILogger _logger;

    public DisplayAddressee(DisplayAdapter display, ILogger logger)
    {
        if (display is null)
        {
            throw new ArgumentException("display cannot be null: ", nameof(display));
        }

        if (logger is null)
        {
            throw new ArgumentException("logger cannot be null: ", nameof(logger));
        }

        _display = display;
        _logger = logger;
    }

    public MessageInfo ReceiveAndSendMessage(Message message)
    {
        var unsentMessage = new MessageInfo();

        _logger.Log($"{DateTime.Now} | Message has been sent");

        _display.ReceiveMessage(message);

        _logger.Log($"{DateTime.Now} | Message has been delivered");

        return unsentMessage;
    }
}
