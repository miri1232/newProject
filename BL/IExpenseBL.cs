using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IExpenseBL
    {
        List<ExpenseDTO> GetAllExpenses();
        List<ExpenseDTO> GetExpensesByBudget(int budget);
        List<ExpenseDTO> GetExpensesByDate(DateTime start, DateTime end);
        List<ExpenseDTO> GetExpensesBySum(double min, double max);
        List<ExpenseDTO> GetExpensesByCategory(int category);
        List<ExpenseDTO> GetExpensesBySubcategory(int subcategory);
        List<ExpenseDTO> GetExpensesByPaymentMethod(int paymentMethod);
        List<ExpenseDTO> GetExpensesByStatus(int status);
        List<ExpenseDTO> SearchExpenses(DateTime start, DateTime end, double min, double max, int category, int Subcategory, int paymentMethod, int status);
        //List<ObjectSumSubCategoryDTO> ReportSubCategoryExpenses(int idBudget);
        //List<ObjectSumCategoryDTO> ReportCategoryExpenses(int idBudget);
        List<TotalSumCategoryDTO> ReportExpenses2(int idBudget);
        List<TotalSumCategoryDTO> ReportExpenses3(int idBudget, DateTime start, DateTime end, int status);


        bool AddExpense(ExpenseDTO expenseDTO);
        bool UpdateExpense(ExpenseDTO expenseDTO);
        bool DeleteExpense(ExpenseDTO expenseDTO);
    }
}