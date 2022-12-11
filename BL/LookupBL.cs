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

        
        public List<BankOfBudgetDTO> GetAllBankOfBudget()
        {
            List<BankOfBudget> bankOfBudgetList = _lookupDAL.GetAllBankOfBudget();
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

       
    }
}
