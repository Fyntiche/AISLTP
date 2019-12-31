using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Privent
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата установления превентивного надзора")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Срок превентивного надзора")]
        public string Srok { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Уголовно-исполнительная инспекция осуществляющая контроль")]
        public string Inspec { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Фамилия ответственого сотрудника")]
        public string Fam { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Имя ответственого сотрудника")]
        public string Ima { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Отчество ответственого сотрудника")]
        public string Otc { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Телефон")]
        public string Tel { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Privent()
        {
            Licos = new List<Lico>();
        }
    }
}