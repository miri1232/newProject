using System;
using System.Collections.Generic;



namespace DTO.Models
{
    public partial class MessageDTO
    {
       
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string Category { get; set; }
        public int? IdBank { get; set; }
        public DateTime? EligibilityAge { get; set; }
  }
}
