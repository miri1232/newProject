using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NumberPaymentsDAL : INumberPaymentsDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<NumberPayments> GetAllNumberPayments()
        {
            try
            {
                return _context.NumberPayments.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNumberPayments(NumberPayments nmberPayments)
        {
            try
            {
                _context.NumberPayments.Add(nmberPayments);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateNumberPayments(int id, NumberPayments nmberPayments)
        {
            try
            {
                NumberPayments currentNumberPayments = _context.NumberPayments.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentNumberPayments).CurrentValues.SetValues(nmberPayments);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletenmberPayments(int id)
        {
            try
            {
                NumberPayments currentnmberPayments = _context.NumberPayments.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentnmberPayments);
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
