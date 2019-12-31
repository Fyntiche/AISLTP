using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Obl
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Область")]
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }
        public ICollection<Address> Addresss { get; set; }

        public Obl()
        {
            Licos = new List<Lico>();
            Addresss = new List<Address>();
        }
    }
}