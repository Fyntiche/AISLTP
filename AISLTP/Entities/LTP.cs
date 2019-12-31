using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class LTP
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Номер ЛТП")]
        public string Nom { get; set; }

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

        [Display(Name = "Телефон дежурной службы")]
        public string Teldej { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        public ICollection<Otrad> Otrads { get; set; }

        public ICollection<Naprav> Napravs { get; set; }

        public LTP()
        {
            Otrads = new List<Otrad>();
            Napravs = new List<Naprav>();
        }
    }
}