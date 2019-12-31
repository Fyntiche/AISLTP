using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AISLTP.Entities
{
    public class Lico
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
        [Display(Name = "Пол")]
        public int? PolID { get; set; }

        public virtual Pol Pol { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна 14 символов")]
        [Display(Name = "Идетификационный номер паспорта")]
        public string Pasport { get; set; }

        [Display(Name = "Национальность")]
        public int? NacID { get; set; }

        public virtual Nac Nac { get; set; }

        [Display(Name = "Область")]
        public int? OblID { get; set; }

        public virtual Obl Obl { get; set; }

        [Display(Name = "Район")]
        public int? RnID { get; set; }

        public virtual Rn Rn { get; set; }

        [Display(Name = "Населенный пункт")]
        public int? NpID { get; set; }

        public virtual Np Np { get; set; }

        [StringLength(255, ErrorMessage = "Длина строки должна до 255 символов")]
        [Display(Name = "Внешность")]
        public string Vneshnost { get; set; }

        [Display(Name = "Фотография")]
        public byte[] Foto { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Prof> Profs { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
        public virtual ICollection<UK> UKs { get; set; }
        public virtual ICollection<Koap> Koaps { get; set; }
        public virtual ICollection<Medic> Medics { get; set; }
        public virtual ICollection<Privent> Privents { get; set; }
        public virtual ICollection<Educ> Educs { get; set; }
        public virtual ICollection<Naprav> Napravs { get; set; }
        public virtual ICollection<Objal> Objals { get; set; }
        public virtual ICollection<Otrad> Otrads { get; set; }
        public virtual ICollection<Debt> Debts { get; set; }
        public virtual ICollection<Svaz> Svazs { get; set; }
        public virtual ICollection<Work> Works { get; set; }
        public virtual ICollection<WorkLTP> WorkLTPs { get; set; }
        public virtual ICollection<Zavis> Zaviss { get; set; }
        public virtual ICollection<Lechen> Lechens { get; set; }
        public virtual ICollection<Obchest> Obchests { get; set; }
        public virtual ICollection<Soderotnosh> Soderotnoshes { get; set; }
        public virtual ICollection<Psix> Psixes { get; set; }
        public virtual ICollection<Discip> Discips { get; set; }
        public virtual ICollection<Samohod> Samohods { get; set; }
        public virtual ICollection<Doc> Docs { get; set; }
        public virtual ICollection<Osv> Osvs { get; set; }

        public Lico()
        {
            Addresses = new List<Address>();
            Profs = new List<Prof>();
            Specs = new List<Spec>();
            UKs = new List<UK>();
            Koaps = new List<Koap>();
            Privents = new List<Privent>();
            Educs = new List<Educ>();
            Napravs = new List<Naprav>();
            Objals = new List<Objal>();
            Otrads = new List<Otrad>();
            Debts = new List<Debt>();
            Svazs = new List<Svaz>();
            Works = new List<Work>();
            WorkLTPs = new List<WorkLTP>();
            Zaviss = new List<Zavis>();
            Obchests = new List<Obchest>();
            Soderotnoshes = new List<Soderotnosh>();
            Psixes = new List<Psix>();
            Discips = new List<Discip>();
            Samohods = new List<Samohod>();
            Docs = new List<Doc>();
            Osvs = new List<Osv>();
        }
    }
}