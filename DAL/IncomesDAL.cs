using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IncomesDAL : IIncomesDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Incomes> GetAllIncomes()
        {
            try
            {
                return _context.Incomes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddIncomes(Incomes incomes)
        {
            try
            {
                _context.Incomes.Add(incomes);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateIncomes(int id, Incomes incomes)
        {
            try
            {
                Incomes currentIncomes = _context.Incomes.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentIncomes).CurrentValues.SetValues(incomes);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteIncomes(int id)
        {
            try
            {
                Incomes currentIncomes = _context.Incomes.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentIncomes);
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
