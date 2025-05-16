using Itmo.ObjectOrientedProgramming.Lab3.Models.UnsentMessages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
public interface IAddressee
{
    public MessageInfo ReceiveAndSendMessage(Message message);
}
