using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string PrenomCli { get; set; }
        public string NomCli { get; set; }
        public DateTime Anniversaire { get; set; }
        public string AdresseCli { get; set; }
        public string EmailCli { get; set; }
        public string NumeroPortable { get; set; }
        public DateTime DateCreaCompte { get; set; }
        public int NbCommandesPasses { get; set; }

    }
}
