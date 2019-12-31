using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Discip
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дисциплинарный проступок")]
        public string Dis { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата совершения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Наказание")]
        public string Nak { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Discip()
        {
            Licos = new List<Lico>();
        }
    }
}