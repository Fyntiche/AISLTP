using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class PeredDoc
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Переданные документы")]
        public string Txt { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public PeredDoc()
        {
            Licos = new List<Lico>();
        }
    }
}