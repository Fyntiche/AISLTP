using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Court
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Населенный пункт")]
        public string Np { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Улица")]
        public string Ul { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дом")]
        public string Dom { get; set; }

        [Display(Name = "Почтовый индекс")]
        public int Pindex { get; set; }

        [Display(Name = "Телефон")]
        public string Teldej { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        public ICollection<UK> UKs { get; set; }

        public Court()
        {
            UKs = new List<UK>();
        }
    }
}