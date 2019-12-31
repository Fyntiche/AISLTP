using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Medic
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Display(Name = "Медицинская комисиия")]
        public int? MedcomId { get; set; }

        public virtual Medcom Medcom { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Результат")]
        public string Result { get; set; }

        [Display(Name = "Фамилия врача")]
        public string Fam { get; set; }

        [Display(Name = "Имя врача")]
        public string Ima { get; set; }

        [Display(Name = "Отчество врача")]
        public string Otch { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public Medic()
        {
            Licos = new List<Lico>();
        }
    }
}