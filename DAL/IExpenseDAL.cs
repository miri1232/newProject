using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IExpenseDAL
    {
        List<Expense> GetAllExpenses();
        bool AddExpense(Expense expense);
        bool UpdateExpense(int id, Expense expense);
        bool DeleteExpense(int id);
       
    }
}