using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabadoMVX.ViewModels
{
    public class PersonaItemVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string SexoNombre { get; set; }
    }
}