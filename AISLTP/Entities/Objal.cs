using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Objal
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Фамилия подавшего заявление")]
        public string Fam { get; set; }

        [Display(Name = "Имя подавшего заявление")]
        public string Ima { get; set; }

        [Display(Name = "Отчество подавшего заявление")]
        public string Otch { get; set; }

        [Display(Name = "Телефон подавшего заявление")]
        public string Tel { get; set; }

        [Display(Name = "Дата обжалования")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Результат")]
        public string Result { get; set; }

        [Display(Name = "Во время нахождения в ЛТП")]
        public bool? Locat { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Objal()
        {
            Licos = new List<Lico>();
        }
    }
}