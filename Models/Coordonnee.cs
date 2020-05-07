using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Coordonnee
    {
        public int Id { get; set; }
        public int Code_Postal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string AdresseCoord { get; set; }
        public bool Facturation { get; set; }
        public bool Livraison { get; set; }
    }
}
