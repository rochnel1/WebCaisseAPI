using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Personnels
    {
        public Personnels()
        {
            Operations = new HashSet<Operations>();
        }

        public int Idpersonnel { get; set; }
        public int Idcaisse { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Profil { get; set; }
        public string Codepersonnel { get; set; }

        public virtual Caisses IdcaisseNavigation { get; set; }
        public virtual ICollection<Operations> Operations { get; set; }
    }
}
