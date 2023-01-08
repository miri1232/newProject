using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IIncomeDAL
    {
        List<Income> GetAllIncomes();
        bool AddIncome(Income income);
        bool UpdateIncome(int id, Income income);
        bool DeleteIncome(int id);
        List<Income> GetIncomesByDate(DateTime start, DateTime end);
        List<Income> GetIncomesBySum(double min, double max);
        List<Income> GetIncomesByCategory(int category);
        List<Income> GetIncomesBySourceOfIncome(int sourceOfIncome);
        List<Income> GetIncomesByStatus(int status);

    }
}