using System;
using System.Collections.Generic;


namespace DTO.Models
{
    public partial class NumberPaymentsDTO
    {
        public int Id { get; set; }
        public int IdExpenses { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }

    }
}
