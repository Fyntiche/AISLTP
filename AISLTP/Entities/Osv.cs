using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Osv
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата освобождения")]
        [DataType(DataType.Date)]
        public DateTime DateOsv { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата прибытия")]
        [DataType(DataType.Date)]
        public DateTime DatePrib { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Ф.И.О. сотрудника контролировавшего прибытие")]
        public string Control { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имеется ли место жительства")]
        public bool? Locat { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Необходимость доставки к дому")]
        public bool? Dost { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Информация о трудоустройстве после освобождения")]
        public string Trud { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Личная позиция лица о трудоустройсте после освобождения")]
        public string Posic { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Необходимость бронирования рабочего места после освобождения")]
        public bool? Bron { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Osv()
        {
            Licos = new List<Lico>();
        }
    }
}