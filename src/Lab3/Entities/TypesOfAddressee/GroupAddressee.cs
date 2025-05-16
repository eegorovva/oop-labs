using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.ConcreteAddressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
using Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
public class GroupAddressee : IAddressee
{
    private Collection<User> _users;
    private ILogger _logger;

    public GroupAddressee(ILogger logger)
    {
        if (logger is null)
        {
            throw new ArgumentException("logger cannot be null: ", nameof(logger));
        }

        _users = new Collection<User>();
        _logger = logger;
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public MessageInfo ReceiveAndSendMessage(Message message)
    {
        var unsentMessage = new MessageInfo();

        foreach (User user in _users)
        {
            _logger.Log($"{DateTime.Now} | Message has been sent to {user.Name} {user.LastName}.");

            if (user.FilterForMessages == 0 || user.FilterForMessages == message.MessageImportance)
            {
                user.ReceiveMessage(message);

                _logger.Log($"{DateTime.Now} | Message has been delivered {user.Name} {user.LastName}.");
            }

            _logger.Log($"{DateTime.Now} | The message was not delivered to {user.Name} {user.LastName}.");

            unsentMessage.GetMessages(message);
        }

        return unsentMessage;
    }
}
