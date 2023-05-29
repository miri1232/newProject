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
                return _context.Expenses.Where(x => x.Category == category).ToList();
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
                return _context.Expenses.Where(x => x.PaymentMethod == paymentMethod).ToList();
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
                return _context.Expenses.Where(x => x.Status == status).ToList();
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
                if (start != null) listExpenses = listExpenses.Where(x => x.Date >= start && x.Date <= end).ToList();
                if (min != null) listExpenses = listExpenses.Where(x => x.Sum >= min && x.Sum <= max).ToList();
                if (category != null) listExpenses = listExpenses.Where(x => x.Category == category).ToList();
                if (Subcategory != null) listExpenses = listExpenses.Where(x => x.Subcategory == Subcategory).ToList();
                if (paymentMethod != null) listExpenses = listExpenses.Where(x => x.PaymentMethod == paymentMethod).ToList();
                if (status != null) listExpenses = listExpenses.Where(x => x.Status == status).ToList();

                return listExpenses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   

        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה
        public List<TotalSumCategory> ReportExpenses2(int idBudget)
        {

            try
            {
                var expenseSummaries = _context.Expenses
                        .Where(e => e.IdBudget == idBudget)
                        .GroupBy(e => new { e.Category, e.Subcategory })
                        .Select(t => new
                        {
                            Category = t.Key.Category,
                            Subcategory = t.Key.Subcategory,
                            TotalSum = t.Sum(e => e.Sum)
                        }).ToList()
                                .GroupBy(t => t.Category)
                                .Select(g => new TotalSumCategory
                                {
                                    IdCategory = g.Key,
                                    SumCategory = g.Sum(t => t.TotalSum),
                                    listSubCategory = g.Select(t => new TotalSumSubCategory
                                    {
                                        IdSubcategory = t.Subcategory,
                                        TotalSum = t.TotalSum
                                    }).ToList()
                                }).ToList();

                return expenseSummaries;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה בטווח תאריכים 
        public List<TotalSumCategory> ReportExpenses3(int idBudget, DateTime start, DateTime end, int status)
        {
            try
            {
                var expenseSummaries = _context.Expenses
                        .Where(e => e.IdBudget == idBudget && e.Date >= start && e.Date <= end && (status==0 || e.Status==status))
                        .GroupBy(e => new { e.Category, e.Subcategory })
                        .Select(t => new
                        {
                            Category = t.Key.Category,
                            Subcategory = t.Key.Subcategory,
                            TotalSum = t.Sum(e => e.Sum)
                        }).ToList()
                                .GroupBy(t => t.Category)
                                .Select(g => new TotalSumCategory
                                {
                                    IdCategory = g.Key,
                                    SumCategory = g.Sum(t => t.TotalSum),
                                    listSubCategory = g.Select(t => new TotalSumSubCategory
                                    {
                                        IdSubcategory = t.Subcategory,
                                        TotalSum = t.TotalSum
                                    }).ToList()
                                }).ToList();

                return expenseSummaries;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Expense AddExpense(Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return expense;
               // return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Expense UpdateExpense(int id, Expense expense)
        {
            try
            {
                Expense currentExpense = _context.Expenses.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentExpense).CurrentValues.SetValues(expense);
                _context.SaveChanges();
                return expense;
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
