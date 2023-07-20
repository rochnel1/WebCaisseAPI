using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Caisses
    {
        public Caisses()
        {
            Operations = new HashSet<Operations>();
            Personnels = new HashSet<Personnels>();
        }

        public int Idcaisse { get; set; }
        public int Idcompte { get; set; }
        public string Codecaisse { get; set; }
        public string Descriptioncaisse { get; set; }
        public string JournalComptable { get; set; }

        public virtual Comptegenerals IdcompteNavigation { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
        public virtual ICollection<Personnels> Personnels { get; set; }
    }
}
