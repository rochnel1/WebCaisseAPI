using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Utilisateurs
    {
        public int IdUtilisateur { get; set; }
        public int Idgpeutilisateur { get; set; }
        public string Login { get; set; }
        public string Nomutilisateur { get; set; }
        public string Prenomutilisateur { get; set; }
        public string Password { get; set; }

        public virtual Groupeutilisateurs IdgpeutilisateurNavigation { get; set; }
    }
}
