using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class User
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Сотрудник")]
        public int? SotrID { get; set; }

        [Display(Name = "Сотрудник")]
        public virtual Sotr Sotr { get; set; }

        [Display(Name = "ЛТП")]
        public int? LtpID { get; set; }

        [Display(Name = "ЛТП")]
        public virtual LTP LTP { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Роль")]
        public int? RoleID { get; set; }

        [Display(Name = "Роль")]
        public virtual Role Role { get; set; }

        public ICollection<Message> Messages { get; set; }

        public User()
        {
            Messages = new List<Message>();
        }
    }
}