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
    public class SourceOfIncomeBL : ISourceOfIncomeBL
    {
        private ISourceOfIncomeDAL _sourceOfIncomeDAL;
        IMapper mapper;

        public SourceOfIncomeBL(ISourceOfIncomeDAL sourceOfIncomeDAL)
        {
            _sourceOfIncomeDAL = sourceOfIncomeDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<SourceOfIncomeDTO> GetAllSourceOfIncomes()
        {
            List<SourceOfIncome> sourceOfIncomeList = _sourceOfIncomeDAL.GetAllSourceOfIncomes();
            List<SourceOfIncomeDTO> listSourceOfIncomeDTO = mapper.Map<List<SourceOfIncome>, List<SourceOfIncomeDTO>>(sourceOfIncomeList);
            return listSourceOfIncomeDTO;
        }

        public SourceOfIncomeDTO GetSourceOfIncomeByID(int idSourceOfIncome)
        {
            SourceOfIncome sourceOfIncome = _sourceOfIncomeDAL.GetSourceOfIncomeByID( idSourceOfIncome);
            SourceOfIncomeDTO sourceOfIncomeDTO = mapper.Map<SourceOfIncome, SourceOfIncomeDTO>(sourceOfIncome);
            return sourceOfIncomeDTO;
        }    

        public bool AddSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO)
        {
            SourceOfIncome currentSourceOfIncome = mapper.Map<SourceOfIncomeDTO, SourceOfIncome>(sourceOfIncomeDTO);
            bool isSucsess = _sourceOfIncomeDAL.AddSourceOfIncome(currentSourceOfIncome);
            return isSucsess;
        }

        public bool UpdateSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO)
        {
            SourceOfIncome currentSourceOfIncome = mapper.Map<SourceOfIncomeDTO, SourceOfIncome>(sourceOfIncomeDTO);
            bool isSucsess = _sourceOfIncomeDAL.UpdateSourceOfIncome(currentSourceOfIncome.Id, currentSourceOfIncome);
            return isSucsess;
        }

        public bool DeleteSourceOfIncome(SourceOfIncomeDTO sourceOfIncomeDTO)
        {
            int idToDelete = sourceOfIncomeDTO.Id;
            bool isSucsess = _sourceOfIncomeDAL.DeleteSourceOfIncome(idToDelete);
            return isSucsess;
        }
    }

    
}
