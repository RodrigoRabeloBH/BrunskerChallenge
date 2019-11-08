using System;
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]      
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 
        public string CellPhone { get; set; } 
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Image { get; set; }       
    }
}