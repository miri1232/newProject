using System;
using System.Collections.Generic;



namespace DTO.Models
{
    public partial class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
