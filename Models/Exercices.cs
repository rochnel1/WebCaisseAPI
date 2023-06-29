using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Exercices
    {
        public Exercices()
        {
            Budgets = new HashSet<Budgets>();
            Operations = new HashSet<Operations>();
            Periodes = new HashSet<Periodes>();
        }

        public int Idexercice { get; set; }
        public string Code { get; set; }
        public DateTime? Datedebut { get; set; }
        public DateTime? Datefin { get; set; }
        public Boolean Statut { get; set; }
        public Boolean Cloture { get; set; }

        public virtual ICollection<Budgets> Budgets { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
        public virtual ICollection<Periodes> Periodes { get; set; }
    }
}
