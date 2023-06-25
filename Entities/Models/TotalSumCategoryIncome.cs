using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public partial class TotalSumCategoryIncome
    {

        public int IdCategory { get; set; }
        public string CategoryDetail { get; set; }
        public double SumCategory { get; set; }
        public List<TotalSumSourceCategoryIncome> listTotalSourceCategoryIncome { get; set; }

    }
}
