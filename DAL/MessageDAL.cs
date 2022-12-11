using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MessageDAL : IMessageDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Message> GetAllMessages()
        {
            try
            {
                return _context.Message.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddMessage(Message message)
        {
            try
            {
                _context.Message.Add(message);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMessage(int id, Message message)
        {
            try
            {
                Message currentMessage = _context.Message.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentMessage).CurrentValues.SetValues(message);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMessage(int id)
        {
            try
            {
                Message currentMessage = _context.Message.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentMessage);
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
