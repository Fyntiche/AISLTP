using System;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Search
    {
        [Display(Name = "Поиск по ФИО")]
        public bool UseFIO { get; set; }
        [Display(Name = "Фрагмент ФИО")]
        public string FIO { get; set; }

        [Display(Name = "Поиск по дате рождения")]
        public bool UseDr { get; set; }
        [Display(Name = "Начало периода")]
        [DataType(DataType.Date)]
        public DateTime DrAt { get; set; }
        [Display(Name = "Окончание периода")]
        [DataType(DataType.Date)]
        public DateTime DrTo { get; set; }

        [Display(Name = "Поиск по дате осуждения")]
        public bool UseDosujd { get; set; }
        [Display(Name = "Начало периода")]
        [DataType(DataType.Date)]
        public DateTime DosujdAt { get; set; }
        [Display(Name = "Окончание периода")]
        [DataType(DataType.Date)]
        public DateTime DosujdTo { get; set; }

        [Display(Name = "Поиск по дате освобождения")]
        public bool UseDosv { get; set; }
        [Display(Name = "Начало периода")]
        [DataType(DataType.Date)]
        public DateTime DosvAt { get; set; }
        [Display(Name = "Окончание периода")]
        [DataType(DataType.Date)]
        public DateTime DosvTo { get; set; }

    }
}