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
        public string Message { get; set; }
        public string NomContact { get; set; }
        public string PrenomContact { get; set; }
        public string EmailContact { get; set; }
        public string TelephoneContact { get; set; }
        public int? UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public int TypeContactId { get; set; }
        public TypeContact TypeContact { get; set; }

    }
}
