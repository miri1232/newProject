using AutoMapper;
using DAL;
using Entities.Models;
using DTO;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class CategoryIncomeBL : ICategoryIncomeBL
    {
        private ICategoryIncomeDAL _categoryIncomeDAL;
        IMapper mapper;

        public CategoryIncomeBL(ICategoryIncomeDAL categoryIncomeDAL)
        {
            _categoryIncomeDAL = categoryIncomeDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<CategoryIncomeDTO> GetAllCategoryIncome()
        {
            List<CategoryIncome> categoryIncomeList = _categoryIncomeDAL.GetAllCategoryIncome();
            List<CategoryIncomeDTO> listCategoryIncomeDTO = mapper.Map<List<CategoryIncome>, List<CategoryIncomeDTO>>(categoryIncomeList);
            return listCategoryIncomeDTO;
        }

        public CategoryIncomeDTO GetCategoryIncomeByID(int idCategoryIncome)
        {
            CategoryIncome categoryIncome = _categoryIncomeDAL.GetCategoryIncomeByID(idCategoryIncome);
            CategoryIncomeDTO categoryIncomeDTO = mapper.Map<CategoryIncome, CategoryIncomeDTO>(categoryIncome);
            return categoryIncomeDTO;
        }

      

        public bool AddCategoryIncome(CategoryIncomeDTO categoryIncomeDTO)
        {
            CategoryIncome currentCategoryIncome = mapper.Map<CategoryIncomeDTO, CategoryIncome>(categoryIncomeDTO);
            bool isSucsess = _categoryIncomeDAL.AddCategoryIncome(currentCategoryIncome);
            return isSucsess;
        }

        public bool UpdateCategoryIncome(CategoryIncomeDTO categoryIncomeDTO)
        {
            CategoryIncome currentCategoryIncome = mapper.Map<CategoryIncomeDTO, CategoryIncome>(categoryIncomeDTO);
            bool isSucsess = _categoryIncomeDAL.UpdateCategoryIncome(currentCategoryIncome.Id, currentCategoryIncome);
            return isSucsess;
        }

        public bool DeleteCategoryIncome(CategoryIncomeDTO categoryIncomeDTO)
        {
            int idToDelete = categoryIncomeDTO.Id;
            bool isSucsess = _categoryIncomeDAL.DeleteCategoryIncome(idToDelete);
            return isSucsess;
        }
    }
}
