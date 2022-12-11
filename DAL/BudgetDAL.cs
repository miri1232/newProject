using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BudgetDAL : IBudgetDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Budget> GetAllBudgets()
        {
            try
            {
                return _context.Budget.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Budget GetBudgetByID(int idBudget)
        {
            try
            {
                return _context.Budget.Where(p => p.Id == idBudget).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBudget(Budget budget)
        {
            try
            {
                _context.Budget.Add(budget);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBudget(int id, Budget budget)
        {
            try
            {
                Budget currentBudget = _context.Budget.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentBudget).CurrentValues.SetValues(budget);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBudget(int id)
        {
            try
            {
                Budget currentBudget = _context.Budget.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentBudget);
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
