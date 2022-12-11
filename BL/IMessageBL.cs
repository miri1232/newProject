using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IMessageBL
    {
        List<MessageDTO> GetAllMessages();
        bool AddMessage(MessageDTO messageDTO);
        bool UpdateMessage(MessageDTO messageDTO);
        bool DeleteMessage(MessageDTO messageDTO);
    }
}