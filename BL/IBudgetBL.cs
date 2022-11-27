using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IBudgetBL
    {
        List<BudgetDTO> GetAllBudget();
        bool AddBudget(BudgetDTO budgetDTO);
        bool UpdateBudget(BudgetDTO budgetDTO);
        bool DeleteBudget(BudgetDTO budgetDTO);
    }
}