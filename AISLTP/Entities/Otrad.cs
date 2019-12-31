using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Otrad
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Display(Name = "ЛТП")]
        public int? LTPID { get; set; }

        public virtual LTP LTP { get; set; }

        [Display(Name = "Дата помещения")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Номер отряда")]
        public string NomOtr { get; set; }

        [Display(Name = "Примечание")]
        public string Prim { get; set; }

        [Display(Name = "Должность начальника отряда")]
        public string Dol { get; set; }

        [Display(Name = "Звание начальника отряда")]
        public string Zv { get; set; }

        [Display(Name = "Фамилия начальника отряда")]
        public string Fam { get; set; }

        [Display(Name = "Имя начальника отряда")]
        public string Ima { get; set; }

        [Display(Name = "Отчество начальника отряда")]
        public string Otch { get; set; }

        [Display(Name = "Телефон")]
        public string Tel { get; set; }

        public virtual ICollection<Lico> Licos { get; set; }

        public Otrad()
        {
            Licos = new List<Lico>();
        }
    }
}