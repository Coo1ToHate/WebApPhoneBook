using System.ComponentModel.DataAnnotations;

namespace WebApPhoneBook.ViewModels
{
    public class CreateUserViewModel
    {
        [Display(Name = "Логин")]
        public string LoginProp { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
