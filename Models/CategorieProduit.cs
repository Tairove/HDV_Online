using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class CategorieProduit
    {
        public int Id { get; set; }
        public string NomCategorieProduit { get; set; }
        public string DescriptionCategorieProduit { get; set; }
        public ICollection<Produit> Produit { get; set; }
    }
}
