using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Auth
    {
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}