using System.ComponentModel.DataAnnotations;

namespace DotNetQ3.ViewModels
{
    public class RegisterViewModel
    {
        [RegularExpression("[a-z]{3,25}",ErrorMessage ="UserNAme Must Be lower case char more than 3 char ")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="PAssword Not MAtch Confimr Password")]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set;}
    }
}
