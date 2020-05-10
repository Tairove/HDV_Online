using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Pays
    {
        public int Id { get; set; }
        public string NomPays { get; set; }
        public ICollection<Coordonnee> Coordonnee { get; set; }
    }
}
