using System;
using System.Collections.Generic;

namespace WebCaisseAPI.Models
{
    public partial class Generalites
    {
        public int Idgeneralite { get; set; }
        public string Raisonsocial { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Region { get; set; }
        public string Pays { get; set; }
        public decimal? Monnaie { get; set; }
        public string Format { get; set; }
        public string Niu { get; set; }
        public string Registrecommerce { get; set; }
        public string Telephone { get; set; }
        public string Adressemail { get; set; }
        public string Siteinternet { get; set; }
    }
}
