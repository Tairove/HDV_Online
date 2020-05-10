using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Coordonnee
    {
        public int Id { get; set; }
        public string Code_Postal { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public bool Facturation { get; set; }
        public bool Livraison { get; set; }
        public Client Client { get; set; }
        public Pays Pays { get; set; }

    }
}
