using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Budgets
    {
        public int Idbudget { get; set; }
        public int Idnatureoperation { get; set; }
        public int Idperiode { get; set; }
        public int Idexercice { get; set; }
        public decimal? Realisation { get; set; }
        public decimal? Ecart { get; set; }
        public int? Pourcentage { get; set; }
        public decimal? Montantbudget { get; set; }
        public string Sensbudget { get; set; }

        public virtual Exercices IdexerciceNavigation { get; set; }
        public virtual Natureoperations IdnatureoperationNavigation { get; set; }
        public virtual Periodes IdperiodeNavigation { get; set; }
    }
}
