using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCaisseAPI.Models
{
    public partial class Operations
    {
        public int Idoperation { get; set; }
        public int Idcaisse { get; set; }
        public int Idpersonnel { get; set; }
        public int Idperiode { get; set; }
        public int Idexercice { get; set; }
        public int Idnatureoperation { get; set; }
        public DateTime? Dateoperation { get; set; }
        public string Description { get; set; }
        public decimal? Montant { get; set; }
        public string Sens { get; set; }
        public string Etat { get; set; }
        public int? Nbrecontrole { get; set; }
        public string Controlerpar { get; set; }
        public string Comptabilserpar { get; set; }
        public DateTime? Datecontrole { get; set; }
        public DateTime? Datecloture { get; set; }
        public DateTime? Datecomptabilisation { get; set; }
        public string Cloturepar { get; set; }
        public int? Regularise { get; set; }
    }
}
