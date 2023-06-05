using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Category> GetAllCategory()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetCategoryByID(int idCategory)
        {
            try
            {
                return _context.Categories.Where(p => p.Id == idCategory).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCategory(int id, Category category)
        {
            try
            {
                Category currentCategory = _context.Categories.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentCategory).CurrentValues.SetValues(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                Category currentCategory = _context.Categories.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentCategory);
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
