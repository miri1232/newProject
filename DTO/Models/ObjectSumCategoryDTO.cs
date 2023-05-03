using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class ObjectSumCategoryDTO
    {

        public int Id { get; set; }
        public Dictionary<int, double> ListSumSubCategory { get; set; }
        public double sum { get; set; }

    }
}
