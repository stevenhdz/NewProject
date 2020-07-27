using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Garantia
    {
        public Garantia()
        {
            Registro = new HashSet<Registro>();
        }

        public int IdGarantia { get; set; }
        public string Garantia1 { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
