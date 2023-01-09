using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ISubcategoryDAL
    {
        List<Subcategory> GetAllSubcategory();
        bool AddSubcategory(Subcategory subcategory);
        bool UpdateSubcategory(int id, Subcategory subcategory);
        bool DeleteSubcategory(int id);
       
    }
}