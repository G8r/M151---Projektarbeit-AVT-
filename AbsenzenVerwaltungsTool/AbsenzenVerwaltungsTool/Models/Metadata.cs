using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbsenzenVerwaltungsTool.Models
{
    public class AbsenzMetadata
    {
        [Required(ErrorMessage = "Bitte Absenz ID eingeben.")]
        [Display(Name = "Absenz ID")]
        public int absenz_id { get; set; }

        [Required(ErrorMessage = "Bitte Datum eingeben.")]
        [Display(Name = "Datum")]
        [DataType(DataType.DateTime, ErrorMessage = "Es muss ein Datum sein")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Datum { get; set; }

        [Required(ErrorMessage = "Bitte anzahl Lektionen eingeben.")]
        [Display(Name = "Lektionen")]
        public double Lektionen { get; set; }

        [Required(ErrorMessage = "Bitte Modul eingeben.")]
        [Display(Name = "Modul")]
        public Nullable<int> modul_id { get; set; }

        [Required(ErrorMessage = "Bitte Schüler eingeben.")]
        [Display(Name = "Schüler")]
        public Nullable<int> schueler_id { get; set; }
    }

    public class ModulMetadata
    {
        [Required(ErrorMessage = "Bitte Modul ID eingeben.")]
        [Display(Name = "Modul ID")]
        public int modul_id { get; set; }

        [Required(ErrorMessage = "Bitte Bezeichnung eingeben.")]
        [Display(Name = "Bezeichnung")]
        public string Bezeichnung { get; set; }

        [Required(ErrorMessage = "Bitte Lehrer eingeben.")]
        [Display(Name = "Lehrer")]
        public int lehrer_id { get; set; }
    }

    public class KlasseMetadata
    {
        [Required(ErrorMessage = "Bitte Klassen ID eingeben.")]
        [Display(Name = "Klasse ID")]
        public int klasse_id { get; set; }

        [Required(ErrorMessage = "Bitte Klassenbezeichnung eingeben.")]
        [Display(Name = "Bezeichnung")]
        public string Bezeichnung { get; set; }
    }

    public class LehrerMetadata
    {
        [Required(ErrorMessage = "Bitte Lehrer ID eingeben.")]
        [Display(Name = "Lehrer ID")]
        public int lehrer_id { get; set; }

        [Required(ErrorMessage = "Bitte Vorname eingeben.")]
        [Display(Name = "Vorname")]
        public string Vorname { get; set; }

        [Required(ErrorMessage = "Bitte Nachname eingeben.")]
        [Display(Name = "Nachname")]
        public string Nachname { get; set; }
    }

    public class SchuelerMetadata
    {
        [Required(ErrorMessage = "Bitte Schüler ID eingeben.")]
        [Display(Name = "Schüler ID")]
        public int schueler_id { get; set; }

        [Required(ErrorMessage = "Bitte Vorname eingeben.")]
        public string Vorname { get; set; }

        [Required(ErrorMessage = "Bitte Nachname eingeben.")]
        public string Nachname { get; set; }

        [Required(ErrorMessage = "Bitte Klasse eingeben.")]
        [Display(Name = "Klasse")]
        public Nullable<int> klasse_id { get; set; }
    }


}