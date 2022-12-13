﻿using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IIncomeDAL
    {
        List<Income> GetAllIncomes();
        bool AddIncome(Income income);
        bool UpdateIncome(int id, Income income);
        bool DeleteIncome(int id);
    }
}