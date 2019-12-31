using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Pol
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Пол")]
        public string Txt { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Pol()
        {
            Licos = new List<Lico>();
        }
    }
}