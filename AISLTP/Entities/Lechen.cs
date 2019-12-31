using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Lechen
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Состоит у врача нарколога")]
        public bool? Sost { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Принятая мера")]
        public string Prin { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Lechen()
        {
            Licos = new List<Lico>();
        }
    }
}