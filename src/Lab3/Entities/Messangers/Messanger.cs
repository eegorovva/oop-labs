using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messangers;
public class Messanger
{
    private string _name;
    private int _filterForMessages;
    private Collection<Message> _messages;

    public Messanger(string name, int filter)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null: ", nameof(name));
        }

        if (filter is 0)
        {
            throw new ArgumentException("filter cannot be zero: ", nameof(filter));
        }

        _filterForMessages = filter;
        _name = name;
        _messages = new Collection<Message>();
    }

    public int FilterForMessages => _filterForMessages;
    public string Name => _name;

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message);
    }

    public virtual void ShowMessages()
    {
        if (_messages.Count == 0)
        {
            throw new ArgumentException("you cannot show an empty messages: ", nameof(_messages));
        }

        foreach (Message message in _messages)
        {
            Console.WriteLine($"Messanger {_name}. {message.Tittle}. {message.Text}");
        }
    }
}
