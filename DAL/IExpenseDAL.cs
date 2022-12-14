using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IExpenseDAL
    {
        List<Expense> GetAllExpenses();
        List<Expense> GetExpensesByDate(DateTime start, DateTime end);
        List<Expense> GetExpensesBySum(double min, double max);
        List<Expense> GetExpensesByCategory(int category);
        List<Expense> GetExpensesBySubcategory(int category);
        List<Expense> GetExpensesByPaymentMethod(int paymentMethod);
        List<Expense> GetExpensesByStatus(int status);
        bool AddExpense(Expense expense);
        bool UpdateExpense(int id, Expense expense);
        bool DeleteExpense(int id);
       
    }
}