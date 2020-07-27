using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Contacto
    {
        public int IdCorreo { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
    }
}
