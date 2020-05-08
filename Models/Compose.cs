using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Compose
    {
        public int Id { get; set; }
        [ForeignKey("CommandeId")]
        public virtual Commande Commande { get; set; }
        [ForeignKey("ProduitId")]
        public virtual Produit Produit { get; set; }

    }
}
