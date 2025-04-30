using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
    }
