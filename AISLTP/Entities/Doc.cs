using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Doc
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Документы, переданные при доставлении")]
        public string Txt { get; set; }

        public ICollection<PeredDoc> PeredDocs { get; set; }

        public Doc()
        {
            PeredDocs = new List<PeredDoc>();
        }
    }
}