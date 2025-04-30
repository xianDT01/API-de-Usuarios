using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

    public class UsuarioUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        public string Nombre { get; set; }

        [EmailAddress]
        public string CorreoElectronico { get; set; }

        public bool Activo { get; set; }
    }
