using System;
using System.Collections.Generic;


namespace DTO.Models
{
    public partial class IncomeDTO
    {
        public int Id { get; set; }
        public int IdBudget { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public int CategoryIncome { get; set; }
        public string CategoryIncomeDetail { get; set; }
        public int SourceOfIncome { get; set; }
        public string SourceOfIncomeDetail { get; set; }
        public string Detail { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodDetail { get; set; }
        public int Status { get; set; }
        public string StatusDetail { get; set; }
        public byte[] Document { get; set; }

    }
}
