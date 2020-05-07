using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string EmailUtilisateur { get; set; }
    }
}
