using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Naprav
    {
        [Key]
        [HiddenInput]
        public int ID { get; set; }

        [Display(Name = "Основания направления")]
        public int? OsnnapID { get; set; }

        public virtual Osnnap Osnnap { get; set; }

        [Display(Name = "ЛТП")]
        public int? LTPID { get; set; }

        public virtual LTP LTP { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата помещения в ЛТП")]
        [DataType(DataType.Date)]
        public DateTime DataPom { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Предполагаемая дата освобожднния")]
        [DataType(DataType.Date)]
        public DateTime DataOsv { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Фамилия сотрудника, доставившего лицо")]
        public string FamD { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Имя сотрудника, доставившего лицо")]
        public string ImaD { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Отчество сотрудника, доставившего лицо")]
        public string OtcD { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Телефон сотрудника, доставившего лицо")]
        public string TelD { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Фамилия сотрудника, оформившего лицо")]
        public string FamO { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Фамилия сотрудника, оформившего лицо")]
        public string ImaO { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Отчество сотрудника, оформившего лицо")]
        public string OtcO { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Телефон сотрудника, оформившего лицо")]
        public string TelO { get; set; }
    }
}