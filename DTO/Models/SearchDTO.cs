using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public partial class SearchDTO
    {
        public int IdBudget { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double SumMin { get; set; }
        public double SumMax { get; set; }
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public int Status { get; set; }
    }
}
