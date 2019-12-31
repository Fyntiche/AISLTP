using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Osnprod
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Основание продления срока")]
        public string Txt { get; set; }
    }
}