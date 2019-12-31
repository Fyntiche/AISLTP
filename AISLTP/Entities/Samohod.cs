using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AISLTP.Entities
{
    public class Samohod
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата побега")]
        [DataType(DataType.Date)]
        public DateTime DateP { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата задержания")]
        [DataType(DataType.Date)]
        public DateTime DateZ { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Ф.И.О. задержавшего сотрудника")]
        public string FIO { get; set; }

        [Display(Name = "Информация о побеге")]
        public int? SamovolID { get; set; }

        public virtual Samovol Samovol { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Примечание")]
        public string Prim { get; set; }

        public ICollection<Lico> Licos { get; set; }

        public Samohod()
        {
            Licos = new List<Lico>();
        }
    }
}