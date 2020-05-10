using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string NomProduit { get; set; }
        public string DescriptionProduit { get; set; }
        public float Prix { get; set; }
        public int QuantiteProd { get; set; }
        public ProduitsCommande ProduitsCommandes { get; set; }
        public CategorieProduit CategorieProduit { get; set; }
    }
}
