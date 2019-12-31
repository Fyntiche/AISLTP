using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Otnosh
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Отношения")]
        public string Txt { get; set; }

        public ICollection<Soderotnosh> Soderotnoshes { get; set; }

        public Otnosh()
        {
            Soderotnoshes = new List<Soderotnosh>();
        }
    }
}