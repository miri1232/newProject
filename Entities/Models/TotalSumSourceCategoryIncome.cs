using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public partial class TotalSumSourceCategoryIncome
    {
        public int Category { get; set; }
        public int IdSourceCategory { get; set; }
        public string SourceCategoryDetail { get; set; }
        public double TotalSum { get; set; }


    }
}
