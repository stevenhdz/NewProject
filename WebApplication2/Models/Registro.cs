using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Registro
    {
        public int IdRegistro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal? ValorUnidad { get; set; }
        public decimal? ValorTotal { get; set; }
        public int CantidadEquipos { get; set; }
        public string Seriales { get; set; }
        public string Correo { get; set; }
        public bool Datos { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionRespuesta { get; set; }
        public string Garantia { get; set; }
        public string NombreTecnico { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Categoria { get; set; }
        public bool? Estado { get; set; }
        public string ProfilePicture { get; set; }

        public virtual Categoria CategoriaNavigation { get; set; }
        public virtual Garantia GarantiaNavigation { get; set; }
        public virtual Marca MarcaNavigation { get; set; }
        public virtual Modelo ModeloNavigation { get; set; }
        public virtual Analista NombreTecnicoNavigation { get; set; }
    }
}
