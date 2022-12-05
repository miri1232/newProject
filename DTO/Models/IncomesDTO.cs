using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class IncomesDTO
    {
        public int Id { get; set; }
        public int IdBudget { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Category { get; set; }
        public string SourceOfIncome { get; set; }
        public string Detail { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public byte[] Document { get; set; }

        //public virtual BudgetDTO IdBudgetNavigation { get; set; }
    }
}
