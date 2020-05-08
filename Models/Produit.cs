using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }
        public int Prix { get; set; }
        public int QuantiteProd { get; set; }
        public ICollection<Compose> Compose { get; set; }
    }
}
