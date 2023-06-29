using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Periodes
    {
        public Periodes()
        {
            Budgets = new HashSet<Budgets>();
            Operations = new HashSet<Operations>();
        }

        public int Idperiode { get; set; }
        public int Idexercice { get; set; }
        public string Codeperiode { get; set; }
        public DateTime? Datedebut { get; set; }
        public DateTime? Datefin { get; set; }

        public virtual Exercices IdexerciceNavigation { get; set; }
        public virtual ICollection<Budgets> Budgets { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
    }
}
