using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class TotalSumCategoryIncomeDTO
    {
        public int IdCategory { get; set; }
        public string CategoryDetail { get; set; }
        public double SumCategory { get; set; }
        public List<TotalSumSourceCategoryIncomeDTO> listSourceCategoryIncome { get; set; }
    }
}
