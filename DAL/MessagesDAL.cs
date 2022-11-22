using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MessagesDAL : IMessagesDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Messages> GetAllMessages()
        {
            try
            {
                return _context.Messages.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddMessages(Messages message)
        {
            try
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMessages(int id, Messages message)
        {
            try
            {
                Messages currentMessage = _context.Messages.SingleOrDefault(x => x.Id == id);
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
                Messages currentMessage = _context.Messages.SingleOrDefault(x => x.Id == id);
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
