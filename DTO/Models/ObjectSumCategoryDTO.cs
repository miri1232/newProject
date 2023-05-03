using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class ObjectSumCategoryDTO
    {

        public int IdCategory { get; set; }
        public Dictionary<int, double> ListSumSubCategory { get; set; }
        public double sumCategory { get; set; }

    }
}
