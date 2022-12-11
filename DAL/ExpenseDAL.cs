using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExpenseDAL : IExpenseDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Expense> GetAllExpenses()
        {
            try
            {
                return _context.Expense.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddExpense(Expense expense)
        {
            try
            {
                _context.Expense.Add(expense);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateExpense(int id, Expense expense)
        {
            try
            {
                Expense currentExpense = _context.Expense.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentExpense).CurrentValues.SetValues(expense);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteExpense(int id)
        {
            try
            {
                Expense currentExpense = _context.Expense.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentExpense);
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
