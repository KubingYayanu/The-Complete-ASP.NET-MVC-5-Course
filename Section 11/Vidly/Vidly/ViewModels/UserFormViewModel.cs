using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Attributes;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UserFormViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
        
        [RequiredIf("Id")]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        public List<UserRoles> Roles { get; set; }

        public UserFormViewModel()
        {

        }

        public UserFormViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Email = user.Email;
            Phone = user.Phone;
            DrivingLicense = user.DrivingLicense;
        }
    }
}