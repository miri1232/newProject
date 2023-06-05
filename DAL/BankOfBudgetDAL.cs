using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BankOfBudgetDAL : IBankOfBudgetDAL
    {
        dbBudgetContext _context = new dbBudgetContext();

        public List<BankOfBudget> GetAllBankOfBudgets()
        {
            try
            {
                return _context.BankOfBudgets.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BankOfBudget GetBankOfBudgetByID(int idBankOfBudget)
        {
            try
            {
                return _context.BankOfBudgets.Where(p => p.Id == idBankOfBudget).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BankOfBudget> GetBankOfBudgetByIdBudget(int _idBudget)
        {
            try
            {
                return _context.BankOfBudgets.Where(b => b.IdBudget == _idBudget).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int AddBankOfBudget(BankOfBudget bankOfBudget)
        {
            try
            {
                _context.BankOfBudgets.Add(bankOfBudget);
                _context.SaveChanges();
                return bankOfBudget.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBankOfBudget(int id, BankOfBudget bankOfBudget)
        {
            try
            {
                BankOfBudget currentBankOfBudget = _context.BankOfBudgets.SingleOrDefault(x => x.Id == id);
                _context.Entry(currentBankOfBudget).CurrentValues.SetValues(bankOfBudget);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBankOfBudget(int id)
        {
            try
            {
                BankOfBudget currentBankOfBudget = _context.BankOfBudgets.SingleOrDefault(x => x.Id == id);
                _context.Remove(currentBankOfBudget);
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
