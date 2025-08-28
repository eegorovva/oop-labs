using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;
public class UnsentMessages : MessageInfo
{
    private Collection<Message> _messages;

    public UnsentMessages()
    {
        _messages = new Collection<Message>();
    }
}
