﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateCommande { get; set; }
        public string Commercial { get; set; }
        public string QuantiteCmd { get; set; }
        public ICollection<Compose> Compose { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

    }
}
