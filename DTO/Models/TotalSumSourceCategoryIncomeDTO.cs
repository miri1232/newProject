using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class TotalSumSourceCategoryIncomeDTO
    {
        public int IdSourceCategory { get; set; }
        public string SourceCategoryDetail { get; set; }
        public double TotalSum { get; set; }

    }
}
