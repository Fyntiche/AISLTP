using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class UK
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пункт")]
        public string Point { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Часть")]
        public string Part { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Статья")]
        public string Article { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Фабула")]
        public string Fabula { get; set; }

        [Display(Name = "Примечание")]
        public string Prim { get; set; }

        [Display(Name = "Суд вынесший решение")]
        public int? CourtID { get; set; }

        public virtual Court Court { get; set; }

        [Display(Name = "Фамилия судьи")]
        public string Fam { get; set; }

        [Display(Name = "Имя судьи")]
        public string Ima { get; set; }

        [Display(Name = "Отчество судьи")]
        public string Otch { get; set; }

        [Display(Name = "Дата вынесения приговора")]
        [DataType(DataType.Date)]
        public DateTime DatePrig { get; set; }

        [Display(Name = "Место отбывания наказания")]
        public string Location { get; set; }

        [Display(Name = "Имеется ли не снятая или непогашенная судимость?")]
        public bool? Sudim { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public UK()
        {
            Licos = new List<Lico>();
        }
    }
}