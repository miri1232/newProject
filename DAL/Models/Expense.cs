using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Expense
    {
        public Expense()
        {
            NumberPayments = new HashSet<NumberPayment>();
        }

        public int Id { get; set; }
        public int IdBudget { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public string Detail { get; set; }
        public int PaymentMethod { get; set; }
        public bool Frequency { get; set; }
        public int NumberOfPayments { get; set; }
        public int Status { get; set; }
        public byte[] Document { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual PaymentMethod PaymentMethodNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual Subcategory SubcategoryNavigation { get; set; }
        public virtual ICollection<NumberPayment> NumberPayments { get; set; }
    }
}
