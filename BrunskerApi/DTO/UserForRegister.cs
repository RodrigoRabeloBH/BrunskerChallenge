using System;
using System.ComponentModel.DataAnnotations;

namespace BrunskerApi.DTO
{
    public class UserForRegister
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(120,MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]  
        public string FullName { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(60,MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string Nickname { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(8,MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string Password { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(11, ErrorMessage = "size should be  {1} characters")] 
        public string Document { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(9,MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="{0} is required")]        
        public string DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Enter a valid email adress")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(30,MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string State { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(30,MinimumLength = 3, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string City { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(9, ErrorMessage = " {0} size should be {1} characters")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(14,MinimumLength = 9, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(14,MinimumLength = 9, ErrorMessage = " {0} size should be between {2} and {1}")]        
        public string CellPhone { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(120,MinimumLength = 5, ErrorMessage = " {0} size should be between {2} and {1}")]
        public string Image { get; set; }        
    }
}