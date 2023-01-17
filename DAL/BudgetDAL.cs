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
                return _context.Budgets.ToList();
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
                return _context.Budgets.Where(p => p.Id == idBudget).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Budget> GetBudgetByUser(string _idUser) {
          try
            {
                List<int> idBudgets;
                idBudgets = _context.Permissions.Where(pr => pr.IdUser.Equals(_idUser)).Select(x=> x.IdBudget).ToList();
                return _context.Budgets.Where(b => idBudgets.Contains(b.Id)).ToList();
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
                _context.Budgets.Add(budget);
                _context.SaveChanges();
                _context.Permissions.Add()
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
                Budget currentBudget = _context.Budgets.SingleOrDefault(x => x.Id == id);
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
                Budget currentBudget = _context.Budgets.SingleOrDefault(x => x.Id == id);
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
