using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab29_brian.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [MaxLength(40)]
        [DisplayName("Please choose a user name")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(40)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your passwords do not match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
