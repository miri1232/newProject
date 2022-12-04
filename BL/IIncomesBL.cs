using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface IIncomesBL
    {
        List<IncomesDTO> GetAllIncomes();
        bool AddIncomes(IncomesDTO incomesDTO);
        bool UpdateIncomes(IncomesDTO incomesDTO);
        bool DeleteIncomes(IncomesDTO incomesDTO);
    }
}