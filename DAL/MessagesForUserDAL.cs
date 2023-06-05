using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class  MessagesForUserDAL: IMessagesForUserDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<MessagesForUser> GetAllMessagesForUser()
        {
            try
            {
                return _context.MessagesForUsers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddMessagesForUser(MessagesForUser messagesForUser)
        {
            try
            {
                _context.MessagesForUsers.Add(messagesForUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMessagesForUser(string id, MessagesForUser messagesForUser)
        {
            try
            {
                MessagesForUser currentMessagesForUser = _context.MessagesForUsers.SingleOrDefault(x => x.IdUser == id);
                _context.Entry(currentMessagesForUser).CurrentValues.SetValues(messagesForUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMessagesForUser(string id)
        {
            try
            {
                MessagesForUser currentMessagesForUser = _context.MessagesForUsers.SingleOrDefault(x => x.IdUser == id);
                _context.Remove(currentMessagesForUser);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
