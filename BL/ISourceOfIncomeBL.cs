﻿using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface ISourceOfIncomeBL
    {
        List<SourceOfIncomeDTO> GetAllSourceOfIncomes();
        List<SourceOfIncomeDTO> GetSourceOfIncomeByCategory(int idSourceOfIncome);

        bool AddSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO);
        bool UpdateSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO);
        bool DeleteSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO);

    }
}