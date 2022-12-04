using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IMessagesForUserBL
    {
        List<MessagesForUserDTO> GetAllMessagesForUser();
        bool AddMessagesForUser(MessagesForUserDTO messagesForUserDTO);
        bool UpdateMessagesForUser(MessagesForUserDTO messagesForUserDTO);
        bool DeleteMessagesForUser(MessagesForUserDTO messagesForUserDTO);
    }
}