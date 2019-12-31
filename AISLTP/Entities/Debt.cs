using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Debt
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Вид задолженности")]
        public int? ViddebtID { get; set; }

        public virtual Viddebt Viddebt { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Сумма")]
        public string Sum { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Debt()
        {
            Licos = new List<Lico>();
        }
    }
}