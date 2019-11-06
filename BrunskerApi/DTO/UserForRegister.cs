using System;

namespace BrunskerApi.DTO
{
    public class UserForRegister
    {
        public int Id { get; set; }  
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; } 
        public string Document { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }        
        public string CellPhone { get; set; }
        public string Photo { get; set; }        
    }
}