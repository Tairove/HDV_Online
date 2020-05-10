using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Role
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string NomRole { get; set; }
        [JsonIgnore]
        public ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
