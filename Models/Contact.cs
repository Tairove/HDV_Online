using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string TypeContact { get; set; }
        public string Question { get; set; }
        public string NomContact { get; set; }
        public string PrenomContact { get; set; }
        public string EmailContact { get; set; }
        [ForeignKey("UtilisateurId")]
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
