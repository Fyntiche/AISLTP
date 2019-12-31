using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Osnsocr
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Основание сокращения срока")]
        public string Txt { get; set; }
    }
}