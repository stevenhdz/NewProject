using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Analista
    {
        public Analista()
        {
            Registro = new HashSet<Registro>();
        }

        public int IdAnalista { get; set; }
        public string NombreTecnico { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
