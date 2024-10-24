using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models.ViewModels {

    public class RegisterViewModel {

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public required string UserName {get; set;}


        [Required(ErrorMessage = "نام الزامی است")]
        [Display(Name = "نام")]
        public required string FirstName {get; set;}

        
        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public required string LastName {get; set;}

        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress]
        public required string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public required string Password {get; set;}

        [DataType(DataType.Password)]
        [Display(Name = "تایید رمز ورود")]
        [Compare("Password", ErrorMessage = "عدم تطابق رمز ورود")]
        public required string ConfirmPassword {get; set;}
    }
}