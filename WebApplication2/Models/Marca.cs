using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Registro = new HashSet<Registro>();
        }

        public int IdMarca { get; set; }
        public string Marca1 { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
