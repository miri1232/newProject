using DTO.Models;
using System.Collections.Generic;

namespace BL
{
   public interface ILookupBL
    {
        List<BankDTO> GetAllBank();
        List<BankOfBudgetDTO> GetAllBankOfBudget();
        List<PermissionDTO> GetAllPermission();
        List<PermissionLevelDTO> GetAllPermissionLevel();

    }
}