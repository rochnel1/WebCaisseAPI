using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Groupeutilisateurs
    {
        public Groupeutilisateurs()
        {
            Utilisateurs = new HashSet<Utilisateurs>();
        }

        public int Idgpeutilisateur { get; set; }
        public string Nomgroupe { get; set; }

        public virtual ICollection<Utilisateurs> Utilisateurs { get; set; }
    }
}
