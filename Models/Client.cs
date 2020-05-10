using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string PrenomClient { get; set; }
        public string NomClient { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateDeNaissance { get; set; }
        public string EmailClient { get; set; }
        public string NumeroPortable { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateCreationCompte { get; set; }
        public int NbCommandesPassees { get; set; }
        public ICollection<Coordonnee> Coordonnees { get; set; }
        public ListeClientCommercial Commercial { get; set; }
        [ForeignKey("UtilisateurId")]
        public Utilisateur Utilisateur { get; set; }

    }
}
