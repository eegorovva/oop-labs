using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.ConcreteAddressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
using Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
public class UserAddressee : IAddressee
{
    private User _user;
    private ILogger _logger;

    public UserAddressee(User user, ILogger logger)
    {
        if (user is null)
        {
            throw new ArgumentException("user cannot be null: ", nameof(user));
        }

        if (logger is null)
        {
            throw new ArgumentException("logger cannot be null: ", nameof(logger));
        }

        _user = user;
        _logger = logger;
    }

    public User User => _user;

    public MessageInfo ReceiveAndSendMessage(Message message)
    {
        var unsentMessage = new MessageInfo();

        _logger.Log($"{DateTime.Now} | Message has been sent to {_user.Name} {_user.LastName}.");

        if (_user.FilterForMessages == 0 || _user.FilterForMessages == message.MessageImportance)
        {
            _user.ReceiveMessage(message);

            _logger.Log($"{DateTime.Now} | Message has been delivered {_user.Name} {_user.LastName}.");
        }
        else
        {
            _logger.Log($"{DateTime.Now} | The message was not delivered to {_user.Name} {_user.LastName}.");
        }

        unsentMessage.GetMessages(message);

        return unsentMessage;
    }
}
