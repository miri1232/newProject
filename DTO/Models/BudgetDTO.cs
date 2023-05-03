using System;
using System.Collections.Generic;


namespace DTO.Models
{
    public partial class BudgetDTO
    {
        public int Id { get; set; }
        public string NameBudget { get; set; }
        public int Type { get; set; }
        public string Manager { get; set; }

    }
}
