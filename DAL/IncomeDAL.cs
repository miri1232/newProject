using DTO.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Income> GetIncomesByBudget(int idBudget)
        {
            try
            {
                return _context.Incomes.Where(x => x.IdBudget == idBudget).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Income> GetIncomesByBudgetGroup(int idBudget)
        {
            try
            {
        var s = (from i in _context.Incomes.Where(x => x.IdBudget == idBudget).Include(x=>x.SourceOfIncomeNavigation).ToList()
                         group i by i.SourceOfIncome into e                        
                        select new {SourceOfIncome=e.Key, categoryName=e.FirstOrDefault()
                        .SourceOfIncomeNavigation.Detail, Sum=e.Sum(x => x.Sum) }).ToList();        

               // return s;

                //.GroupBy(x => new { x.CategoryIncome, x.SourceOfIncome })
                //.Select(g => new
                //{
                //    category = g.Key.CategoryIncome,
                //    source = g.Key.SourceOfIncome,
                //    incomes = g.ToList(),
                //});
                //.GroupBy(x => new { x.CategoryIncome, x.SourceOfIncome },(key, group) => new
                //{
                //    Key1 = key.CategoryIncome,
                //    Key2 = key.SourceOfIncome,
                //    Result = group.ToList()
                //});
                return _context.Incomes.Where(x => x.IdBudget == idBudget).ToList();
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
                return _context.Incomes.Where(x => x.Date >= start && x.Date <= end).ToList();
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

        public List<Income> GetIncomesByCategory(int category)
        {
            try
            {
                return _context.Incomes.Where(x => x.CategoryIncome == category).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Income> GetIncomesBySourceOfIncome(int sourceOfIncome)
        {
            try
            {
                return _context.Incomes.Where(x => x.SourceOfIncome == sourceOfIncome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Income> GetIncomesByStatus(int status)
        {
            try
            {
                return _context.Incomes.Where(x => x.Status == status).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //שליפת דוחות בסיכום קטגוריה+תת קטגוריה בטווח תאריכים 
        public List<TotalSumCategoryIncome> ReportIncomes(int idBudget, DateTime start, DateTime end, int status)
        {
            try
            {
                var expenseSummaries = _context.Incomes
                        .Where(e => e.IdBudget == idBudget && e.Date >= start && e.Date <= end && (status == 0 || e.Status == status))
                        .GroupBy(e => new { e.CategoryIncome, e.SourceOfIncome })
                        .Select(t => new
                        {
                            Category = t.Key.CategoryIncome,
                            SourceCategory = t.Key.SourceOfIncome,
                            TotalSum = t.Sum(e => e.Sum)
                        }).ToList()
                                .GroupBy(t => t.Category)
                                .Select(g => new TotalSumCategoryIncome
                                {
                                    IdCategory = g.Key,
                                    SumCategory = g.Sum(t => t.TotalSum),
                                    listTotalSourceCategoryIncome = g.Select(t => new TotalSumSourceCategoryIncome
                                    {
                                        IdSourceCategory = t.SourceCategory,
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
