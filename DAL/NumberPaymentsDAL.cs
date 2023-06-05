using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NumberPaymentsDAL : INumberPaymentsDAL
    {
     //   dbBudgetContext _context = new dbBudgetContext();

        dbBudgetContext _context = new dbBudgetContext();


        public List<NumberPayment> GetAllNumberPayments()
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

        public bool AddNumberPayments(NumberPayment numberPayments)
        {
            try
            {
                _context.NumberPayments.Add(numberPayments);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateNumberPayments(int id, NumberPayment numberPayments)
        {
            try
            {
                NumberPayment currentNumberPayments = _context.NumberPayments.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentNumberPayments).CurrentValues.SetValues(numberPayments);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteNumberPayments(int id)
        {
            try
            {
                NumberPayment currentnumberPayments = _context.NumberPayments.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentnumberPayments);
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
