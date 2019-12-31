using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Vidsv
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Вид связи")]
        public string Txt { get; set; }

        public ICollection<Svaz> Svazs { get; set; }

        public Vidsv()
        {
            Svazs = new List<Svaz>();
        }
    }
}