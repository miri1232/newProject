﻿using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IExpenseDAL
    {
        List<Expense> GetAllExpenses();
        List<Expense> GetExpensesByBudget(int budget);
        List<Expense> GetExpensesByDate(DateTime start, DateTime end);
        List<Expense> GetExpensesBySum(double min, double max);
        List<Expense> GetExpensesByCategory(int category);
        List<Expense> GetExpensesBySubcategory(int Subcategory);
        List<Expense> GetExpensesByPaymentMethod(int paymentMethod);
        List<Expense> GetExpensesByStatus(int status);
        List<Expense> SearchExpenses(DateTime start, DateTime end, double min, double max , int category , int Subcategory, int paymentMethod, int status);
        //List<ObjectSumSubCategory> ReportSubCategoryExpenses(int idBudget);
        //List<ObjectSumCategory> ReportCategoryExpenses(int idBudget);
        List<TotalSumCategory> ReportExpenses2(int idBudget);


        bool AddExpense(Expense expense);
        bool UpdateExpense(int id, Expense expense);
        bool DeleteExpense(int id);
       
    }
}