using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Np
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Населенный пункт")]
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }
        public ICollection<Address> Addresss { get; set; }

        public Np()
        {
            Licos = new List<Lico>();
            Addresss = new List<Address>();
        }
    }
}