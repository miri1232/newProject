using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IExpensesDAL
    {
        List<Expenses> GetAllExpenses();
        bool AddExpense(Expenses expenses);
        bool UpdateExpenses(int id, Expenses expenses);
        bool DeleteExpenses(int id);
       
    }
}