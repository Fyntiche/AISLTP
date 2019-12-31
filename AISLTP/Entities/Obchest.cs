using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Obchest
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Участие в общественной жизни")]
        public string Uch { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Obchest()
        {
            Licos = new List<Lico>();
        }
    }
}