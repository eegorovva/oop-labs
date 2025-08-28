using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messangers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Adapters;
public class MessangerAdapter
{
    private Messanger _messanger;
    private int _filter;

    public MessangerAdapter(Messanger messanger)
    {
        if (messanger is null)
        {
            throw new ArgumentException("messanger cannot be null:", nameof(messanger));
        }

        _messanger = messanger;
        _filter = messanger.FilterForMessages;
    }

    public int FilterForMessages => _filter;
    public string Name => _messanger.Name;

    public void SendMessage(Message message)
    {
        _messanger.ReceiveMessage(message);
    }
}
