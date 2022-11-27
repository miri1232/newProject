using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IIncomesDAL
    {
        List<Incomes> GetAllIncomes();
        bool AddIncomes(Incomes incomes);
        bool UpdateIncomes(int id, Incomes incomes);
        bool DeleteIncomes(int id);
    }
}