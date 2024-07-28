using System.ComponentModel.DataAnnotations;

namespace DotNetQ3.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="REmember ME")]
        public bool IsRemember { get; set; }
    }
}
