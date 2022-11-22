using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DTO.Models
{
    public partial class Expenses
    {
        public Expenses()
        {
            NumberPayments = new HashSet<NumberPayments>();
        }

        public int Id { get; set; }
        public int IdBudget { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Detail { get; set; }
        public string PaymentMethod { get; set; }
        public bool Frequency { get; set; }
        public int NumberOfPayments { get; set; }
        public string Statusstatus { get; set; }
        public byte[] Document { get; set; }

        public virtual Budget IdBudgetNavigation { get; set; }
        public virtual ICollection<NumberPayments> NumberPayments { get; set; }
    }
}
