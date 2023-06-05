using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class TypeBudget
    {
        public TypeBudget()
        {
            Budgets = new HashSet<Budget>();
        }

        public int Id { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<Budget> Budgets { get; set; }
    }
}
