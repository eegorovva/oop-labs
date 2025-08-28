using System;
namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
public class Topic
{
    private string _name;
    private IAddressee _addressee;

    public Topic(string name, IAddressee addresse)
    {
        if (name is null)
        {
            throw new ArgumentException("name cannot be null: ", nameof(name));
        }

        if (addresse is null)
        {
            throw new ArgumentException("addresse cannot be null: ", nameof(addresse));
        }

        _name = name;
        _addressee = addresse;
    }

    public string Name => _name;

    public void SendMessage(Message message)
    {
        _addressee.ReceiveAndSendMessage(message);
    }
}
