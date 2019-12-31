using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Viddebt
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Вид задолженности")]
        public string Txt { get; set; }

        public ICollection<Debt> Debts { get; set; }

        public Viddebt()
        {
            Debts = new List<Debt>();
        }
    }
}