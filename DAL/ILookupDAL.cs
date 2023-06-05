using Entities.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ILookupDAL
    {
        List<Bank> GetAllBank();
        List<BankOfBudget> GetAllBankOfBudget(int idBudget);
        List<Permission> GetAllPermission();
        List<PermissionLevel> GetAllPermissionLevel();
        List<Status> GetAllStatus();
        List<PaymentMethod> GetAllPaymentMethod();
        List<TypeBudget> GetAllTypeBudget();


    }
}