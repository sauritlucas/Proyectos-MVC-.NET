using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SegundoParcialSaurit.Models
{
    public class Socio
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        
        public int IdTipoDocumento { get; set; }
        [Required]
        public string NroDocumento { get; set; }
        public int IdDeporte { get; set; }
    }
}