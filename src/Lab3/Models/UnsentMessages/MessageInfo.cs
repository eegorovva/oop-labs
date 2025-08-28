using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;
public class MessageInfo
{
    private Collection<Message> _messages;

    public MessageInfo()
    {
        _messages = new Collection<Message>();
    }

    public void GetMessages(Message message)
    {
        _messages.Add(message);
    }
}
