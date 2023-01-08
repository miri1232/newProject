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
        public int CategoryIncome { get; set; }
        public int SourceOfIncome { get; set; }
        public string Detail { get; set; }
        public int PaymentMethod { get; set; }
        public int Status { get; set; }
        public byte[] Document { get; set; }

        public virtual CategoryIncome CategoryIncomeNavigation { get; set; }
        public virtual Budget IdBudgetNavigation { get; set; }
        public virtual PaymentMethod PaymentMethodNavigation { get; set; }
        public virtual SourceOfIncome SourceOfIncomeNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
    }
}
