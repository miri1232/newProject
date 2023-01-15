using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IBudgetDAL
    {
         List<Budget> GetAllBudgets();
         Budget GetBudgetByID(int idBudget);
        List<Budget> GetBudgetByUser(string idUser);
         bool AddBudget(Budget budget);
         bool UpdateBudget(int id, Budget budget);
         bool DeleteBudget(int id);
       
    }
}