using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.ConcreteAddressee;
public class User
{
    private string _name;
    private string _lastName;
    private int _filterForMessages;
    private Collection<bool> _messagesStatus;
    private Collection<Message> _messages;

    public User(string name, string lastName, int filter)
    {
        if (name is null)
        {
            throw new ArgumentException("name cannot be less or null ", nameof(name));
        }

        if (lastName is null)
        {
            throw new ArgumentException("last name cannot be less or null ", nameof(lastName));
        }

        _filterForMessages = filter;
        _name = name;
        _lastName = lastName;
        _messagesStatus = new Collection<bool>();
        _messages = new Collection<Message>();
    }

    public int FilterForMessages => _filterForMessages;
    public string Name => _name;
    public string LastName => _lastName;
    public Collection<Message>? Messages => _messages;
    public Collection<bool> MessagesStatus => _messagesStatus;

    public virtual void ReceiveMessage(Message message)
    {
        _messages.Add(message);
        _messagesStatus.Add(false);
    }

    public virtual void ReadMessage(int index)
    {
        if (_messages is not null && _messagesStatus[index] == false && (index >= 0 && _messages.Count > index))
        {
            _messagesStatus[index] = true;
        }
        else if (_messagesStatus[index] == true)
        {
            throw new InvalidOperationException("You cannot read the message you have read");
        }
    }
}
