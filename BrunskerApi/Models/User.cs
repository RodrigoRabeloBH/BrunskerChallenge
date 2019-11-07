using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrunskerApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Document { get; set; }
        public string Gender { get; set; }      
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 
        public string CellPhone { get; set; } 
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Image { get; set; }       
    }
}