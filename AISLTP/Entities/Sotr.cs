using System;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Sotr
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Cod_sotr { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime Dvi { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Ima { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Fio { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Otc { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime Dr { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Sex { get; set; }
    }
}