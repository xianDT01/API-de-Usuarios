using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
    public class ProductoCreateDTO
    {
        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Range(0.01, 999999)]
        public decimal Precio { get; set; }

        public bool Activo { get; set; }        
    }
