using System;
using System.Collections.Generic;



namespace DTO.Models
{
    public partial class MessagesForUserDTO
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdMessages { get; set; }
        public bool Status { get; set; }
    
    }
}
