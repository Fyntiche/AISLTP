using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Osndosr
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Основание для досрочного освобождения")]
        public string Txt { get; set; }
    }
}