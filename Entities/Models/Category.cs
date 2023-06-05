using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class Category
    {
        public Category()
        {
            Expenses = new HashSet<Expense>();
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
