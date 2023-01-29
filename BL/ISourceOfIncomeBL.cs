using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface ISourceOfIncomeBL
    {
        List<SourceOfIncomeDTO> GetAllSourceOfIncomes();
        SourceOfIncomeDTO GetSourceOfIncomeByID(int idSourceOfIncome);

        bool AddSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO);
        bool UpdateSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO);
        bool DeleteSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO);

    }
}