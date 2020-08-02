using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Analista = new HashSet<Analista>();
        }

        public int IdRol { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Analista> Analista { get; set; }
    }
}
