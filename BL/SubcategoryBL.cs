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
    public class SubcategoryBL  : ISubcategoryBL
    {
        private ISubcategoryDAL _subcategoryDAL;
        IMapper mapper;

        public SubcategoryBL(ISubcategoryDAL subcategoryDAL)
        {
            _subcategoryDAL = subcategoryDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public List<SubcategoryDTO> GetAllSubcategory()
        {
            List<Subcategory> subcategorysList = _subcategoryDAL.GetAllSubcategory();
            List<SubcategoryDTO> listSubcategorysDTO = mapper.Map<List<Subcategory>, List<SubcategoryDTO>>(subcategorysList);
            return listSubcategorysDTO;
        }


        public bool AddSubcategory(SubcategoryDTO subcategoryDTO)
        {
            Subcategory currentSubcategory = mapper.Map<SubcategoryDTO, Subcategory>(subcategoryDTO);
            bool isSucsess = _subcategoryDAL.AddSubcategory(currentSubcategory);
            return isSucsess;
        }

        public bool UpdateSubcategory(SubcategoryDTO subcategoryDTO)
        {
            Subcategory currentSubcategory = mapper.Map<SubcategoryDTO, Subcategory>(subcategoryDTO);
            bool isSucsess = _subcategoryDAL.UpdateSubcategory(currentSubcategory.Id, currentSubcategory);
            return isSucsess;
        }

        public bool DeleteSubcategory(SubcategoryDTO subcategoryDTO)
        {
            int idToDelete = subcategoryDTO.Id;
            bool isSucsess = _subcategoryDAL.DeleteSubcategory(idToDelete);
            return isSucsess;
        }

      
    }
}
