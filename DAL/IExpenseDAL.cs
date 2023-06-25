using Entities.Models;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IExpenseDAL
    {
        List<Expense> GetAllExpenses();
        List<Expense> GetExpensesByBudget(int budget);
        List<Expense> GetExpensesByDate(int idBudget);
        List<Expense> GetExpensesBySum(double min, double max);
        List<Expense> GetExpensesByCategory(int category);
        List<Expense> GetExpensesBySubcategory(int Subcategory);
        List<Expense> GetExpensesByPaymentMethod(int paymentMethod);
        List<Expense> GetExpensesByStatus(int status);
        List<Expense> SearchExpenses(DateTime start, DateTime end, double min, double max , int category , int Subcategory, int paymentMethod, int status);
        List<Expense> SearchExpensesObject(SearchDTO searchDTO);
        List<TotalSumCategory> ReportExpenses2(int idBudget);
        List<TotalSumCategory> ReportExpenses3(int idBudget, DateTime start, DateTime end, int status);
        int AddExpense(Expense expense);
        Expense UpdateExpense(int id, Expense expense);
        bool DeleteExpense(int id);
       
    }
}