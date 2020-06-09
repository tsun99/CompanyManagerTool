using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagerTool.Models
{
    public enum Counties
    {
        [Display(Name = "Alytus")]
        Alytus,
        Kaunas,
        Klaipėda,
        Marijampolė,
        Panevėžys,
        Šiauliai,
        Tauragė,
        Telšiai,
        Utena,
        Vilnius
    }
    public class Company
    {
        

        [Key]
        public int Id { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("Įmonės Kodas")]
        public string CompanyCode { get; set; }


        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Pavadinimas")]
        public string CompanyName { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("El. Paštas")]
        public string Email { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("Blogas El. Paštas")]
        public string WrongEmail { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("Kontaktinis Tel.Nr")]
        public string ContactNumber { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("Apskritis")]
        public string County { get; set; }


        [Column(TypeName = "varchar(250)")]
        public string VMVT { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("Kita Info")]
        public string AdditionalInfo { get; set; }


        [Column(TypeName = "varchar(250)")]
        [DisplayName("Aktuali Veikla")]
        public string Activities { get; set; }
        
    }
}
