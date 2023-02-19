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
   public class BankOfBudgetBL : IBankOfBudgetBL
    {

        private IBankOfBudgetDAL _bankOfBudgetDAL;
        private ILookupDAL _lookupDAL;

        IMapper mapper;

        public BankOfBudgetBL(IBankOfBudgetDAL bankOfBudgetDAL, ILookupDAL lookupDAL)
        {
            _bankOfBudgetDAL = bankOfBudgetDAL;
            _lookupDAL = lookupDAL;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }


      
        public List<BankOfBudgetDTO> GetAllBankOfBudgets()
        {
        List<BankOfBudget> bankOfBudgetList = _bankOfBudgetDAL.GetAllBankOfBudgets();
        List<BankOfBudgetDTO> ListBankOfBudgetDTO = mapper.Map<List<BankOfBudget>, List<BankOfBudgetDTO>>(bankOfBudgetList);

            List<Bank> banks = _lookupDAL.GetAllBank();
            ListBankOfBudgetDTO.ForEach(item => item.Link
            = banks.FirstOrDefault(b => b.Id == item.IdBank).Link);
           
            ListBankOfBudgetDTO.ForEach(item => item.NameBank
          = banks.FirstOrDefault(b => b.Id == item.IdBank).NameBank);
         
            ListBankOfBudgetDTO.ForEach(item => item.Logo_Bank
          = banks.FirstOrDefault(b => b.Id == item.IdBank).Logo_Bank);

            return ListBankOfBudgetDTO;
        }

        public BankOfBudgetDTO GetBankOfBudgetByID(int idBankOfBudget)
        {

            BankOfBudget bankOfBudget = _bankOfBudgetDAL.GetBankOfBudgetByID(idBankOfBudget);
            BankOfBudgetDTO BankOfBudgetDTO = mapper.Map<BankOfBudget, BankOfBudgetDTO>(bankOfBudget);

            List<Bank> banks = _lookupDAL.GetAllBank();
          //  BankOfBudgetDTO(item => item.Link
          //  = banks.FirstOrDefault(b => b.Id == item.IdBank).Link);

          //  BankOfBudgetDTO.ForEach(item => item.NameBank
          //= banks.FirstOrDefault(b => b.Id == item.IdBank).NameBank);

          //  BankOfBudgetDTO.ForEach(item => item.Logo_Bank
          //= banks.FirstOrDefault(b => b.Id == item.IdBank).Logo_Bank);

            return BankOfBudgetDTO;
        }


        public List<BankOfBudgetDTO> GetBankOfBudgetByIdBudget(int idBudget)
        {
            List<BankOfBudget> bankOfBudgetList = _bankOfBudgetDAL.GetBankOfBudgetByIdBudget(idBudget);
            List<BankOfBudgetDTO> ListBankOfBudgetDTO = mapper.Map<List<BankOfBudget>, List<BankOfBudgetDTO>>(bankOfBudgetList);

            List<Bank> banks = _lookupDAL.GetAllBank();
            ListBankOfBudgetDTO.ForEach(item => item.Link
            = banks.FirstOrDefault(b => b.Id == item.IdBank).Link);

            ListBankOfBudgetDTO.ForEach(item => item.NameBank
          = banks.FirstOrDefault(b => b.Id == item.IdBank).NameBank);

            ListBankOfBudgetDTO.ForEach(item => item.Logo_Bank
          = banks.FirstOrDefault(b => b.Id == item.IdBank).Logo_Bank);

            return ListBankOfBudgetDTO;
        }

        public bool AddBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO)
               {
            BankOfBudget currentBankOfBudget = mapper.Map<BankOfBudgetDTO, BankOfBudget>(bankOfBudgetDTO);
            bool isSucsess = _bankOfBudgetDAL.AddBankOfBudget(currentBankOfBudget);
            return isSucsess;
        }

        public bool UpdateBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO)
        {
            BankOfBudget currentBankOfBudget = mapper.Map<BankOfBudgetDTO, BankOfBudget>(bankOfBudgetDTO);
            bool isSucsess = _bankOfBudgetDAL.UpdateBankOfBudget(currentBankOfBudget.Id, currentBankOfBudget);
            return isSucsess;
        }

        public bool DeleteBankOfBudget(BankOfBudgetDTO bankOfBudgetDTO)
        {
            int idToDelete = bankOfBudgetDTO.Id;
            bool isSucsess = _bankOfBudgetDAL.DeleteBankOfBudget(idToDelete);
            return isSucsess;
        }



    }
}
