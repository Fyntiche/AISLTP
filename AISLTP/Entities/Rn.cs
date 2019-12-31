using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Rn
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Район")]
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public Rn()
        {
            Licos = new List<Lico>();
            Addresses = new List<Address>();
        }
    }
}