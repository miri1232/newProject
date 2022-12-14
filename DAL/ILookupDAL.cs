using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ILookupDAL
    {
        List<Bank> GetAllBank();
        List<BankOfBudget> GetAllBankOfBudget();
        List<Permission> GetAllPermission();
        List<PermissionLevel> GetAllPermissionLevel();
        List<Status> GetAllStatus();
        List<PaymentMethod> GetAllPaymentMethod();
        List<TypeBudget> GetAllTypeBudget();


    }
}