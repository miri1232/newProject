using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public partial class TotalSumCategory
    {

        public int IdCategory { get; set; }
        public string CategoryDetail { get; set; }
        public double SumCategory { get; set; }
        public List<TotalSumSubCategory> listSubCategory { get; set; }

    }
}
