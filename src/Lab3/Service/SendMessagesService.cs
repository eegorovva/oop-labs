using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;
public class SendMessagesService
{
    private Collection<Topic> _topics;

    public SendMessagesService()
    {
        _topics = new Collection<Topic>();
    }

    public void SendMessage(Message message, string topicName)
    {
        Topic topic = GetTopic(topicName);

        topic.SendMessage(message);
    }

    public Topic? FindTopic(string name)
    {
        return _topics.FirstOrDefault(topic => topic.Name == name);
    }

    public Topic GetTopic(string topicName)
    {
        Topic? foundedTopic = FindTopic(topicName);

        if (foundedTopic == null)
        {
            throw new ArgumentException("topic doesn't exist: ", nameof(topicName));
        }

        return foundedTopic;
    }

    public void CreateTopic(string name, IAddressee addressee)
    {
        if (FindTopic(name) != null)
        {
            throw new ArgumentException("topic already exist: ", nameof(name));
        }

        var topic = new Topic(name, addressee);

        _topics.Add(topic);
    }
}
