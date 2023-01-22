using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IBudgetBL
    {
        List<BudgetDTO> GetAllBudgets();
        BudgetDTO GetBudgetByID(int idBudget);
        List<BudgetDTO> GetBudgetByUser(string idUser);

        bool AddBudget(BudgetDTO budgetDTO);
        bool UpdateBudget(BudgetDTO budgetDTO);
        bool DeleteBudget(BudgetDTO budgetDTO);

    }
}