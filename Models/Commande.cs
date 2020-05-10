using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Commande
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateCommande { get; set; }
        public ProduitsCommande ProduitsCommandes { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

    }
}
