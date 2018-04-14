using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "電話號碼")]
        public string Number { get; set; }
    }
}