using DTO.Models;
using System.Collections.Generic;

namespace BL
{
   public interface ILookupBL
    {
        List<BankDTO> GetAllBank();
        List<BankOfBudgetDTO> GetAllBankOfBudget(int idBudget);
        List<PermissionDTO> GetAllPermission();
        List<PermissionLevelDTO> GetAllPermissionLevel();
        List<StatusDTO> GetAllStatus();
        List<PaymentMethodDTO> GetAllPaymentMethod();
        List<TypeBudgetDTO> GetAllTypeBudget();
    }
}