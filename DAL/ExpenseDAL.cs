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
        public List<Expense> GetExpensesByBudget(int budget)
        {
            try
            {
                return _context.Expenses.Where(x => x.IdBudget == budget).ToList();
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
       
        public List<Expense> GetExpensesBySum(double min, double max)
        {
            try
            {
                return _context.Expenses.Where(x => x.Sum >= min && x.Sum <= max).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Expense> GetExpensesByCategory(int category)
        {
            try
            {
                return _context.Expenses.Where(x => x.Category==category).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Expense> GetExpensesBySubcategory(int subcategory)
        {
            try
            {
                return _context.Expenses.Where(x => x.Subcategory == subcategory).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Expense> GetExpensesByPaymentMethod(int paymentMethod)
        {
            try
            {
                return _context.Expenses.Where(x => x.PaymentMethod==paymentMethod).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Expense> GetExpensesByStatus(int status)
        {
            try
            {
                return _context.Expenses.Where(x => x.Status==status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Expense> SearchExpenses(DateTime start, DateTime end, double min, double max, int category, int Subcategory, int paymentMethod, int status) 
        {
            try
            {
                List<Expense> listExpenses = _context.Expenses.ToList();
                if(start!=null)  listExpenses= listExpenses.Where(x => x.Date >= start && x.Date <= end).ToList();
                if(min!=null)  listExpenses= listExpenses.Where(x => x.Sum >= min && x.Sum <= max).ToList();
                if(category != null)  listExpenses= listExpenses.Where(x => x.Category == category).ToList();
                if(Subcategory != null)  listExpenses= listExpenses.Where(x => x.Subcategory == Subcategory).ToList();
                if(paymentMethod != null)  listExpenses= listExpenses.Where(x => x.PaymentMethod == paymentMethod).ToList();
                if(status != null)  listExpenses= listExpenses.Where(x => x.Status == status).ToList();

                return listExpenses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ObjectSumCategory> ReportCategoryExpenses(int idBudget)
        {
            try
            {                 
                var expenseSummaries = _context.Expenses.Where(e => e.IdBudget == idBudget)
                .GroupBy(e =>   e.Category )
                .Select(g => new ObjectSumCategory
                {
                    IdCategory = g.Key,
                    sumCategory = g.Sum(e => e.Sum)
                })
            .ToList();

                return expenseSummaries;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ObjectSumSubCategory> ReportSubCategoryExpenses(int idBudget)
        {
            try
            {
                var expenseSummaries = _context.Expenses.Where(e => e.IdBudget == idBudget)
                .GroupBy(e => new { e.Category, e.Subcategory })
                .Select(g => new ObjectSumSubCategory
                {
                    Category = g.Key.Category,
                    Subcategory = g.Key.Subcategory,
                    TotalSum = g.Sum(e => e.Sum)
                })
            .ToList();

                return expenseSummaries;
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
