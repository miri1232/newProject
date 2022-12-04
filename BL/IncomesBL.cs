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
    public class IncomesBL : IIncomesBL
    {
        private IIncomesDAL _incomesDAL;
        IMapper mapper;

        public IncomesBL(IIncomesDAL incomesDAL)
        {
            _incomesDAL = incomesDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<IncomesDTO> GetAllIncomes()
        {
            List<Incomes> incomesList = _incomesDAL.GetAllIncomes();
            List<IncomesDTO> listIncomesDTO = mapper.Map<List<Incomes>, List<IncomesDTO>>(incomesList);
            return listIncomesDTO;
        }


        public bool AddIncomes(IncomesDTO incomesDTO)
        {
            Incomes currentIncomes = mapper.Map<IncomesDTO, Incomes>(incomesDTO);
            bool isSucsess = _incomesDAL.AddIncomes(currentIncomes);
            return isSucsess;
        }

        public bool UpdateIncomes(IncomesDTO incomesDTO)
        {
            Incomes currentIncomes = mapper.Map<IncomesDTO, Incomes>(incomesDTO);
            bool isSucsess = _incomesDAL.UpdateIncomes(currentIncomes.Id, currentIncomes);
            return isSucsess;
        }

        public bool DeleteIncomes(IncomesDTO incomesDTO)
        {
            int idToDelete = incomesDTO.Id;
            bool isSucsess = _incomesDAL.DeleteIncomes(idToDelete);
            return isSucsess;
        }
    }
}
