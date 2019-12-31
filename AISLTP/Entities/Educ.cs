using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Educ
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Образование")]
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Educ()
        {
            Licos = new List<Lico>();
        }
    }
}