using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Nac
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Национальность")]
        public string Txt { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public Nac()
        {
            Licos = new List<Lico>();
        }
    }
}