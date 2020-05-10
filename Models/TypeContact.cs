using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDV_Online.Models
{
    public class TypeContact
    {
        public int Id { get; set; }
        public string TitreTypeContact { get; set; }
        public ICollection<Contact> Contact { get; set; }
    }
}
