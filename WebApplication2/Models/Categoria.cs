using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Registro = new HashSet<Registro>();
        }

        public int IdCategoria { get; set; }
        public string Categoria1 { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
