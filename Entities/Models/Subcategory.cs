using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public int Category { get; set; }
        public string Detail { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
