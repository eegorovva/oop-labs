using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
using Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
public class MessangerAddressee : IAddressee
{
    private MessangerAdapter _messangerAdapter;
    private ILogger _logger;

    public MessangerAddressee(MessangerAdapter messangerAdapter, ILogger logger)
    {
        if (logger is null)
        {
            throw new ArgumentException("logger cannot be null: ", nameof(logger));
        }

        if (messangerAdapter is null)
        {
            throw new ArgumentException("messanger adapter cannot be null: ", nameof(messangerAdapter));
        }

        _messangerAdapter = messangerAdapter;
        _logger = logger;
    }

    public MessageInfo ReceiveAndSendMessage(Message message)
    {
        var unsentMessage = new MessageInfo();

        _logger.Log($"{DateTime.Now} | Message has been sent to {_messangerAdapter.Name}.");

        if (_messangerAdapter.FilterForMessages == 0 || _messangerAdapter.FilterForMessages == message.MessageImportance)
        {
            _messangerAdapter.SendMessage(message);

            _logger.Log($"{DateTime.Now} | Message has been delivered {_messangerAdapter.Name}.");
        }

        _logger.Log($"{DateTime.Now} | The message was not delivered to {_messangerAdapter.Name}.");

        unsentMessage.GetMessages(message);

        return unsentMessage;
    }
}
