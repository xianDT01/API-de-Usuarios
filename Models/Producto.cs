using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCrud.Models
{
    public class Producto
    {
        public int Id {get;set;}
        public  String Nombre {get;set;} = string.Empty;
        public string Descripcion{get;set;} = string.Empty;
        public DateTime FechaDeAlta {get;set;}
        public Decimal Precio {get;set;}
        public bool Activo {get;set;}
    }
}