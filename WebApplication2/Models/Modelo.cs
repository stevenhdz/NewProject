using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Registro = new HashSet<Registro>();
        }

        public int IdModelo { get; set; }
        public string Modelo1 { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
