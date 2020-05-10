using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class ListeClientCommercial
    {
        public int Id { get; set; }
        [ForeignKey("ClientId")]
        public ICollection<Client> Client { get; set; }
        [ForeignKey("CommercialId")]
        public Utilisateur Commercial { get; set; }
    }
}
