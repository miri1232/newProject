using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class LookupDAL : ILookupDAL
    {
        dbBudgetContext _context = new dbBudgetContext();


        public List<Bank> GetAllBank() 
        {
            try
            {
                return _context.Banks.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BankOfBudget> GetAllBankOfBudget()

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

        public List<Permission> GetAllPermission()

        {
            try
            {
                return _context.Permissions.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PermissionLevel> GetAllPermissionLevel()

        {
            try
            {
                return _context.PermissionLevels.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Status> GetAllStatus()
        {
            try
            {
                return _context.Statuses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PaymentMethod> GetAllPaymentMethod()
        {
             try
            {
                return _context.PaymentMethods.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TypeBudget> GetAllTypeBudget()
        {
            try
            {
                return _context.TypeBudgets.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
