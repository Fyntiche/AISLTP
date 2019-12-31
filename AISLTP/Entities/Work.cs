using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Work
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Место работы до направления в ЛТП")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Занимаемая должность")]
        public string Dol { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Work()
        {
            Licos = new List<Lico>();
        }
    }
}