using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IExpensesBL
    {
        List<ExpensesDTO> GetAllExpenses();
        bool AddExpenses(ExpensesDTO expensesDTO);
        bool UpdateExpenses(ExpensesDTO expensesDTO);
        bool DeleteExpenses(ExpensesDTO expensesDTO);
    }
}