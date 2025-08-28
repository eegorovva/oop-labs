using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    private string _title;
    private string _text;
    private int _messageImportance;

    public Message(string title, string text, int messageImportance)
    {
        if (title is null)
        {
            throw new ArgumentException("title cannot be null: ", nameof(title));
        }

        if (text is null)
        {
            throw new ArgumentException("text cannot be null: ", nameof(text));
        }

        if (messageImportance < 0 || messageImportance > 1)
        {
            throw new ArgumentException("message importance cannot be less than 0 and greater than 1  ", nameof(messageImportance));
        }

        _title = title;
        _text = text;
        _messageImportance = messageImportance;
    }

    public int MessageImportance => _messageImportance;
    public string Tittle => _title;
    public string Text => _text;
}
