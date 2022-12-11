using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IExpenseBL
    {
        List<ExpenseDTO> GetAllExpenses();
        bool AddExpense(ExpenseDTO expenseDTO);
        bool UpdateExpense(ExpenseDTO expenseDTO);
        bool DeleteExpense(ExpenseDTO expenseDTO);
    }
}