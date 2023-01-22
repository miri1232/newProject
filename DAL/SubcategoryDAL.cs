using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SubcategoryDAL : ISubcategoryDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<Subcategory> GetAllSubcategory()
        {
            try
            {
                return _context.Subcategories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddSubcategory(Subcategory subcategory)
        {
            try
            {
                _context.Subcategories.Add(subcategory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateSubcategory(int id, Subcategory subcategory)
        {
            try
            {
                Subcategory currentSubcategory = _context.Subcategories.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentSubcategory).CurrentValues.SetValues(subcategory);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteSubcategory(int id)
        {
            try
            {
                Subcategory currentSubcategory = _context.Subcategories.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentSubcategory);
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
