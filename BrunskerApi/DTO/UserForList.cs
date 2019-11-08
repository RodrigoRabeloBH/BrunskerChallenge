using System;
using System.ComponentModel.DataAnnotations;

namespace BrunskerApi.DTO
{
    public class UserForList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Document { get; set; }
        public string Gender { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Image { get; set; }
        public string CellPhone { get; set; }
    }
}