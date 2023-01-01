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
                return _context.Expenses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Expense> GetExpensesByDate(DateTime start, DateTime end)
        {
            try
            {
                return _context.Expenses.Where(x => x.Date >= start && x.Date <= end).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public List<Expense> GetExpensesBySum(double start, double end)
        {
            try
            {
                return _context.Expenses.Where(x => x.Sum >= start && x.Sum <= end).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Expense> GetExpensesByCategory(string category)
        {
            try
            {
                return _context.Expenses.Where(x => x.Category == category).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Expense> GetExpensesByPaymentMethod(string paymentMethod)
        {
            try
            {
                return _context.Expenses.Where(x => x.PaymentMethod == paymentMethod).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Expense> GetExpensesByStatus(string status)
        {
            try
            {
                return _context.Expenses.Where(x => x.Statusstatus == status).ToList();
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
                _context.Expenses.Add(expense);
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
                Expense currentExpense = _context.Expenses.SingleOrDefault(x => x.Id == id);
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
                Expense currentExpense = _context.Expenses.SingleOrDefault(x => x.Id == id);
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
