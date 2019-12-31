using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class WorkLTP
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Отношение к труду")]
        public string Otn { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Трудоустройство в ЛТП")]
        public string Trud { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public WorkLTP()
        {
            Licos = new List<Lico>();
        }
    }
}