using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string NomRole { get; set; }
        public ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
