using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class ProduitsCommande
    {
        public int Id { get; set; }

        public int IdCommande { get; set; }
        public Commande Commande { get; set; }
        public int IdProduit { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
        public int PrixTotalLigne { get; set; }

    }
}
