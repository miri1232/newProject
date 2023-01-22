using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class CategoryIncome
    {
        public CategoryIncome()
        {
            Incomes = new HashSet<Income>();
            SourceOfIncomes = new HashSet<SourceOfIncome>();
        }

        public int Id { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<SourceOfIncome> SourceOfIncomes { get; set; }
    }
}
