using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IMessagesBL
    {
        List<MessagesDTO> GetAllMessages();
        bool AddMessages(MessagesDTO messagesDTO);
        bool UpdateMessages(MessagesDTO messagesDTO);
        bool DeleteMessages(MessagesDTO messagesDTO);
    }
}