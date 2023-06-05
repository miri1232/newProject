using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CategoryIncomeDAL : ICategoryIncomeDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<CategoryIncome> GetAllCategoryIncome()
        {
            try
            {
                return _context.CategoryIncomes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CategoryIncome GetCategoryIncomeByID(int idCategoryIncome)
        {
            try
            {
                return _context.CategoryIncomes.Where(p => p.Id == idCategoryIncome).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool AddCategoryIncome(CategoryIncome categoryIncome)
        {
            try
            {
                _context.CategoryIncomes.Add(categoryIncome);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCategoryIncome(int id, CategoryIncome categoryIncome)
        {
            try
            {
                CategoryIncome currentCategoryIncome = _context.CategoryIncomes.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentCategoryIncome).CurrentValues.SetValues(categoryIncome);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCategoryIncome(int id)
        {
            try
            {
                CategoryIncome currentCategoryIncome = _context.CategoryIncomes.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentCategoryIncome);
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
