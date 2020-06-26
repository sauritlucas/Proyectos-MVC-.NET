using SabadoMVX.AccesoDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabadoMVX.ViewModels.Reportes
{
    public class InfoGralVM
    {
        public List<SexoItemVM> listaSexos { get; set; }
        public List<PersonaItemVM> listaPersonas { get; set; }
        public InfoGralVM()
        {
            listaSexos = new List<SexoItemVM>();
            listaPersonas = new List<PersonaItemVM>();
            CargarVariables();
        }

        private void CargarVariables()
        {
            listaSexos = AD_Reportes.ObtenerCantidadPersonasPorSexo();
            listaPersonas = AD_Reportes.ObtenerReportePersonas();
        }
    }
}