using System.ComponentModel.DataAnnotations;

namespace Winterra.Models.InputModels
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required.")]
        [MinLength(4, ErrorMessage = "Email must be at least 4 characters.")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(4, ErrorMessage = "Password must be at least 4 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public required string Password { get; set; }
    }
}
