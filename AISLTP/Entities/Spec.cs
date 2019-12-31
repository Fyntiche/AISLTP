using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Spec
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Специальность")]
        public string Txt { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public Spec()
        {
            Licos = new List<Lico>();
        }
    }
}