using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Zavis
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Зависимость")]
        public string Zav { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Принятая мера")]
        public string Prin { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Zavis()
        {
            Licos = new List<Lico>();
        }
    }
}