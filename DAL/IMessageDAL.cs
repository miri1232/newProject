using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IMessageDAL
    {
        List<Message> GetAllMessages();
        bool AddMessage(Message message);
        bool UpdateMessage(int id, Message message);
        bool DeleteMessage(int id);
       
    }
}