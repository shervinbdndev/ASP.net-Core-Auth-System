using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models.ViewModels {

    public class LoginViewModel {

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public required string UserName {get; set;}


        [Required]
        [DataType(DataType.Password)]
        public required string Password {get; set;}

        
        [Display(Name = "منو به خاطر بسپار")]
        public bool RememberMe {get; set;}
    }
}