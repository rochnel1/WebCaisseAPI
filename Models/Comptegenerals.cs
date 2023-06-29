using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Comptegenerals
    {
        public Comptegenerals()
        {
            Caisses = new HashSet<Caisses>();
            Natureoperations = new HashSet<Natureoperations>();
        }

        public int Idcompte { get; set; }
        public string Numcompte { get; set; }
        public string Intitule { get; set; }

        public virtual ICollection<Caisses> Caisses { get; set; }
        public virtual ICollection<Natureoperations> Natureoperations { get; set; }
    }
}
