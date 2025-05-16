using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.ConcreteAddressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.LoggingProxy;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messangers;
using Itmo.ObjectOrientedProgramming.Lab3.Service;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessagesTest
{
    private SendMessagesService _messagesService;

    public MessagesTest()
    {
        _messagesService = new SendMessagesService();
    }

    [Fact]
    public void SendMessageToUserAndMessagesStatusIsFalse()
    {
        var user = new User("Vlad", "Korneev", 0);
        ILogger logger = new Logger();
        var userAddressee = new UserAddressee(user, logger);
        var message = new Message("Tittle", "Text", 0);

        _messagesService.CreateTopic("topic", userAddressee);
        _messagesService.SendMessage(message, "topic");

        Assert.False(user.MessagesStatus[0]);
    }

    [Fact]
    public void SendMessageToUserAndMarkMessagesStatusToTrue()
    {
        var user = new User("Vlad", "Korneev", 0);
        ILogger logger = new Logger();
        var userAddressee = new UserAddressee(user, logger);
        var message = new Message("Tittle", "Text", 0);

        _messagesService.CreateTopic("topic", userAddressee);
        _messagesService.SendMessage(message, "topic");

        user.ReadMessage(0);

        Assert.True(user.MessagesStatus[0]);
    }

    [Fact]
    public void ReadMessageWithTrueStatusAndGetError()
    {
        var user = new User("Vlad", "Korneev", 0);
        ILogger logger = new Logger();
        var userAddressee = new UserAddressee(user, logger);
        var message = new Message("Tittle", "Text", 0);

        _messagesService.CreateTopic("topic", userAddressee);
        _messagesService.SendMessage(message, "topic");

        user.ReadMessage(0);

        Assert.Throws<InvalidOperationException>(() => user.ReadMessage(0));
    }

    [Fact]
    public void SendMessageToAddresseeButMessageWillNotBeDeliveredBecauseOfFilter()
    {
        User mockUser = Substitute.For<User>("Vladimir", "Korneev", 1);
        ILogger logger = new Logger();
        var userAddressee = new UserAddressee(mockUser, logger);
        var message = new Message("Tittle", "Text", 0);

        _messagesService.CreateTopic("topic", userAddressee);
        _messagesService.SendMessage(message, "topic");

        mockUser.DidNotReceive().ReceiveMessage(message);
    }

    [Fact]
    public void MessageDeliveredAndLogWritten()
    {
        var user = new User("Vladimir", "Korneev", 1);
        ILogger mockLogger = Substitute.For<Logger>();
        var userAddressee = new UserAddressee(user, mockLogger);
        var message = new Message("Tittle", "Text", 1);

        _messagesService.CreateTopic("topic", userAddressee);
        _messagesService.SendMessage(message, "topic");

        mockLogger.Received().Log($"{DateTime.Now} | Message has been delivered {user.Name} {user.LastName}.");
    }

    [Fact]
    public void SendMessageToMessangerAndGetExcepetedValue()
    {
        Messanger mockMessagner = Substitute.For<Messanger>("telegram", 1);
        ILogger logger = new Logger();
        var adapter = new MessangerAdapter(mockMessagner);
        var messangerAddressee = new MessangerAddressee(adapter, logger);
        var message = new Message("Tittle", "Text", 1);

        _messagesService.CreateTopic("topic", messangerAddressee);
        _messagesService.SendMessage(message, "topic");

        mockMessagner.ShowMessages();

        mockMessagner.Received().ReceiveMessage(message);
        mockMessagner.Received().ShowMessages();
    }
}
