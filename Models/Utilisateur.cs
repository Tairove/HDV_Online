using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public Role Role { get; set; }
        public ListeClientCommercial ListeClientCommercial { get; set; }
        public Client Client { get; set; }
        public ICollection<Contact>? Contact { get; set; }
    }
}
