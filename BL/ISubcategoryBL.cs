using DTO.Models;
using System.Collections.Generic;

namespace BL
{
    public interface ISubcategoryBL
    {
        List<SubcategoryDTO> GetAllSubcategory();
        List<SubcategoryDTO> GetSubcategoryByCategory(int category);

        bool AddSubcategory(SubcategoryDTO subcategoryDTO);
        bool UpdateSubcategory(SubcategoryDTO subcategoryDTO);
        bool DeleteSubcategory(SubcategoryDTO subcategoryDTO);
    }
}