using System;
using System.Collections.Generic;


namespace DTO.Models
{
    public partial class ExpenseDTO
    {
        public int Id { get; set; }
        public int IdBudget { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public int Category { get; set; }
        public string CategoryDetail { get; set; }
        public int Subcategory { get; set; }
        public string SubcategoryDetail { get; set; }
        public string Detail { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodDetail { get; set; }
        public bool Frequency { get; set; }
      //  public int NumberOfPayments { get; set; }
        public int Status { get; set; }
        public string StatusDetail { get; set; }
        public byte[] Document { get; set; }

    }
}
