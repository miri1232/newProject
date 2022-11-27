using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExpensesDAL : IExpensesDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Expenses> GetAllExpenses()
        {
            try
            {
                return _context.Expenses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddExpense(Expenses expenses)
        {
            try
            {
                _context.Expenses.Add(expenses);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateExpenses(int id, Expenses expenses)
        {
            try
            {
                Expenses currentExpenses = _context.Expenses.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentExpenses).CurrentValues.SetValues(expenses);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteExpenses(int id)
        {
            try
            {
                Expenses currentExpenses = _context.Expenses.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentExpenses);
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
