using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IncomeDAL : IIncomeDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Income> GetAllIncomes()
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

        public List<Income> GetIncomesByDate(DateTime start, DateTime end)
        {
            try
            {
                return _context.Incomes.Where(x =>x.Date >= start && x.Date <= end).ToList() ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public List<Income> GetIncomesBySum(double min, double max)
        {
            try
            {
                return _context.Incomes.Where(x => x.Sum >= min && x.Sum <= max).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Income> GetIncomesByCategory(string category)
        {
            try
            {
                return _context.Incomes.Where(x => x.Category.Equals(category)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Income> GetIncomesBySourceOfIncome(string sourceOfIncome)
        {
            try
            {
                return _context.Incomes.Where(x => x.SourceOfIncome.Equals(sourceOfIncome)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Income> GetIncomesByStatus(string status)
        {
            try
            {
                return _context.Incomes.Where(x => x.Status.Equals(status)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool AddIncome(Income income)
        {
            try
            {
                _context.Incomes.Add(income);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateIncome(int id, Income income)
        {
            try
            {
                Income currentIncome = _context.Incomes.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentIncome).CurrentValues.SetValues(income);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteIncome(int id)
        {
            try
            {
                Income currentIncome = _context.Incomes.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentIncome);
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
