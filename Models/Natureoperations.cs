using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Natureoperations
    {
        public Natureoperations()
        {
            Budgets = new HashSet<Budgets>();
            Operations = new HashSet<Operations>();
        }

        public int Idnatureoperation { get; set; }
        public int Idcompte { get; set; }
        public string Description { get; set; }
        public short? Typenature { get; set; }
        public string Codenature { get; set; }
        public short Sensnature { get; set; }

        public virtual Comptegenerals IdcompteNavigation { get; set; }
        public virtual ICollection<Budgets> Budgets { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
    }
}
