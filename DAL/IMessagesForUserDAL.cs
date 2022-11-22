using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IMessagesForUserDAL
    {
        List<MessagesForUser> GetAllMessagesForUser();
        bool AddMessagesForUser(MessagesForUser messagesForUser);
        bool UpdateMessagesForUser(string id, MessagesForUser messagesForUser);
        bool DeleteMessagesForUser(string id);
      
    }
}