using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Psix
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Информация психолога")]
        public string Psi { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Ф.И.О. психолога")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Psix()
        {
            Licos = new List<Lico>();
        }
    }
}