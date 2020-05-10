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
        [ForeignKey("CommandeId")]
        public Commande IdCommande { get; set; }

        [ForeignKey("IdProduit")]
        public ICollection<Produit> Produit { get; set; }

    }
}
