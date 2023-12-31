﻿using System;
using System.Collections.Generic;

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
        public int? Controlerpar { get; set; }
        public string Comptabilserpar { get; set; }
        public DateTime? Datecontrole { get; set; }
        public DateTime? Datecloture { get; set; }
        public DateTime? Datecomptabilisation { get; set; }
        public int? Cloturepar { get; set; }
        public int? Regularise { get; set; }

        public virtual Personnels ControlerparNavigation { get; set; }
        public virtual Caisses IdcaisseNavigation { get; set; }
        public virtual Exercices IdexerciceNavigation { get; set; }
        public virtual Natureoperations IdnatureoperationNavigation { get; set; }
        public virtual Periodes IdperiodeNavigation { get; set; }
        public virtual Personnels IdpersonnelNavigation { get; set; }
    }
}
