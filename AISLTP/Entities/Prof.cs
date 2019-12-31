using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Prof
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Профессия")]
        public string Txt { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public Prof()
        {
            Licos = new List<Lico>();
        }
    }
}