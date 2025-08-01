using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.ComponentModel.DataAnnotations;

namespace Web_DemoMVCWithEFCoreCodeFirst.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password & Confirm Password must match.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }
    }
}
