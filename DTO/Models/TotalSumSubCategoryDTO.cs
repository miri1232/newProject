using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class TotalSumSubCategoryDTO
    {
        public int IdSubcategory { get; set; }
        public string SubcategoryDetail { get; set; }
        public double TotalSum { get; set; }
    }
}
