using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public partial class ObjectSumSubCategory
    {
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public double TotalSum { get; set; }
    }
}
