using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Svaz
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Фамилия")]
        public string Fam { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Имя")]
        public string Ima { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Отчество")]
        public string Otc { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime Dr { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Вид связи")]
        public int? VidsvID { get; set; }

        public virtual Vidsv Vidsv { get; set; }

        [Display(Name = "Примечание")]
        public string Prim { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public Svaz()
        {
            Licos = new List<Lico>();
        }
    }
}