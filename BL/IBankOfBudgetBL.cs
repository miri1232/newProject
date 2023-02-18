using DTO.Models;
using System.Collections.Generic;

namespace BL
{
   public interface IBankOfBudgetBL
    {
        List<BankOfBudgetDTO> GetAllBankOfBudgets();
        BankOfBudgetDTO GetBankOfBudgetByID(int idBankOfBudget);
        List<BankOfBudgetDTO> GetBankOfBudgetByIdBudget(int idBudget);
        bool AddBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO);
        bool UpdateBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO);
        bool DeleteBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO);
    }
}