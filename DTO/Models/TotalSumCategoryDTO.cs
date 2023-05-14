using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class TotalSumCategoryDTO
    {
        public int IdCategory { get; set; }
        public string CategoryDetail { get; set; }
        public double SumCategory { get; set; }
        public List<TotalSumSubCategoryDTO> listSubCategory { get; set; }
    }
}
