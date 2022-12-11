using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Income
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

        public virtual Budget IdBudgetNavigation { get; set; }
    }
}
