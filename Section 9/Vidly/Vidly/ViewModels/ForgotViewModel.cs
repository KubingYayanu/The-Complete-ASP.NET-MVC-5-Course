using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }
}