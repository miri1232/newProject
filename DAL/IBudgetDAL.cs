using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IBudgetDAL
    {
         List<Budget> GetAllBudgets();
         bool AddBudget(Budget budget);
         bool UpdateBudget(int id, Budget budget);
         bool DeleteBudget(int id);
       
    }
}