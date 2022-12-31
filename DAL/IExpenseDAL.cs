using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IExpenseDAL
    {
        List<Expense> GetAllExpenses();
        List<Expense> GetExpensesByDate(DateTime start, DateTime end);
        List<Expense> GetExpensesBySum(double start, double end);
        List<Expense> GetExpensesByCategory(string category);
        List<Expense> GetExpensesByPaymentMethod(string paymentMethod);
        List<Expense> GetExpensesByStatus(string status);
        bool AddExpense(Expense expense);
        bool UpdateExpense(int id, Expense expense);
        bool DeleteExpense(int id);
       
    }
}