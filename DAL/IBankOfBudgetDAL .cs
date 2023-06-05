using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IBankOfBudgetDAL
    {
         List<BankOfBudget> GetAllBankOfBudgets();
        BankOfBudget GetBankOfBudgetByID(int idBankOfBudget);
        List<BankOfBudget> GetBankOfBudgetByIdBudget(int idBudget);
         int AddBankOfBudget(BankOfBudget bBankOfudget);
         bool UpdateBankOfBudget(int id, BankOfBudget bankOfBudget);
         bool DeleteBankOfBudget(int id);
       
    }
}