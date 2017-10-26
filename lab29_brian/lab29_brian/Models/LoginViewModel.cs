using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab29_brian.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
