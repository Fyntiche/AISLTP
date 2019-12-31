using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Osnnap
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Основание для направления в ЛТП")]
        public string Txt { get; set; }

        public ICollection<Naprav> Napravs { get; set; }

        public Osnnap()
        {
            Napravs = new List<Naprav>();
        }
    }
}