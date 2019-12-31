using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Message
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Пользователь")]
        public int? UserID { get; set; }

        public virtual User User { get; set; }

        [Display(Name = "Просмотрено")]
        public bool IsRead { get; set; }
    }
}