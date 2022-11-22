using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IMessagesDAL
    {
        List<Messages> GetAllMessages();
        bool AddMessages(Messages message);
        bool UpdateMessages(int id, Messages message);
        bool DeleteMessage(int id);
       
    }
}