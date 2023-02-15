using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class LookupBL : ILookupBL
    {

        private ILookupDAL _lookupDAL;
        IMapper mapper;

        public LookupBL(ILookupDAL lookupDAL)
        {
            _lookupDAL = lookupDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }


       public List<BankDTO> GetAllBank()
        {
            List<Bank> bankList = _lookupDAL.GetAllBank();
            List<BankDTO> ListBankDTO = mapper.Map<List<Bank>, List<BankDTO>>(bankList);
            return ListBankDTO;
        }

        
        public List<BankOfBudgetDTO> GetAllBankOfBudget(int idBudget)
        {
            List<BankOfBudget> bankOfBudgetList = _lookupDAL.GetAllBankOfBudget(idBudget);
        List<BankOfBudgetDTO> ListBankOfBudgetDTO = mapper.Map<List<BankOfBudget>, List<BankOfBudgetDTO>>(bankOfBudgetList);
            return ListBankOfBudgetDTO;
        }

     
        public List<PermissionDTO> GetAllPermission()
        {
            List<Permission> permissionList = _lookupDAL.GetAllPermission();
            List<PermissionDTO> ListPermissionDTO = mapper.Map<List<Permission>, List<PermissionDTO>>(permissionList);
            return ListPermissionDTO;
        }

       
        public List<PermissionLevelDTO> GetAllPermissionLevel()
{
            List<PermissionLevel> permissionLevelList = _lookupDAL.GetAllPermissionLevel();
            List<PermissionLevelDTO> ListPermissionLevelDTO = mapper.Map<List<PermissionLevel>, List<PermissionLevelDTO>>(permissionLevelList);
            return ListPermissionLevelDTO;
}

        public List<PaymentMethodDTO> GetAllPaymentMethod()
        {
            List<PaymentMethod> PaymentMethodList = _lookupDAL.GetAllPaymentMethod();
            List<PaymentMethodDTO> ListPaymentMethodDTO = mapper.Map<List<PaymentMethod>, List<PaymentMethodDTO>>(PaymentMethodList);
            return ListPaymentMethodDTO;
        }

        public List<StatusDTO> GetAllStatus()
        {
            List<Status> StatusList = _lookupDAL.GetAllStatus();
            List<StatusDTO> ListStatusDTO = mapper.Map<List<Status>, List<StatusDTO>>(StatusList);
            return ListStatusDTO;
        }

        public List<TypeBudgetDTO> GetAllTypeBudget()
        {
            List<TypeBudget> TypeBudgetList = _lookupDAL.GetAllTypeBudget();
            List<TypeBudgetDTO> ListTypeBudgetDTO = mapper.Map<List<TypeBudget>, List<TypeBudgetDTO>>(TypeBudgetList);
            return ListTypeBudgetDTO;
        }
    }
}
