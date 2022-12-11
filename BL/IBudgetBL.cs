using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IBudgetBL
    {
        List<BudgetDTO> GetAllBudgets();
        BudgetDTO GetBudgetByID(int idBudget);
        bool AddBudget(BudgetDTO budgetDTO);
        bool UpdateBudget(BudgetDTO budgetDTO);
        bool DeleteBudget(BudgetDTO budgetDTO);
    }
}