using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SourceOfIncomeDAL : ISourceOfIncomeDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<SourceOfIncome> GetAllSourceOfIncomes()
        {
            try
            {
                return _context.SourceOfIncomes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SourceOfIncome GetSourceOfIncomeByID(int idSourceOfIncome)
        {
            try
            {
                return _context.SourceOfIncomes.Where(p => p.Id == idSourceOfIncome).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    


        public bool AddSourceOfIncome(SourceOfIncome sourceOfIncome)
        {
            try
            {
                _context.SourceOfIncomes.Add(sourceOfIncome);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateSourceOfIncome(int id, SourceOfIncome sourceOfIncome)
        {
            try
            {
                SourceOfIncome currentSourceOfIncome = _context.SourceOfIncomes.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentSourceOfIncome).CurrentValues.SetValues(sourceOfIncome);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteSourceOfIncome(int id)
        {
            try
            {
                SourceOfIncome currentSourceOfIncome = _context.SourceOfIncomes.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentSourceOfIncome);
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
