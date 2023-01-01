using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IExpenseBL
    {
        List<ExpenseDTO> GetAllExpenses();
        List<ExpenseDTO> GetExpensesByDate(DateTime start, DateTime end);
        List<Expense> GetExpensesBySum(double start, double end);
        List<Expense> GetExpensesByCategory(string category);
        List<Expense> GetExpensesByPaymentMethod(string paymentMethod);
        List<ExpenseDTO> GetExpensesByStatus(string status);
        bool AddExpense(ExpenseDTO expenseDTO);
        bool UpdateExpense(ExpenseDTO expenseDTO);
        bool DeleteExpense(ExpenseDTO expenseDTO);
    }
}