using SegundoParcialSaurit.AccesoDeDatos;
using SegundoParcialSaurit.Models;
using SegundoParcialSaurit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SegundoParcialSaurit.Controllers
{
    public class SocioController : Controller
    {
        // GET: Socio
        public ActionResult AltaSocio()
        {
            //Lista tipo Documento
            List<TipoDocItemVM> listaTipoDocumentos = AD_Socios.ObtenerListaTipoDocumentos();

            List<SelectListItem> itemsTipoDocumento = listaTipoDocumentos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipoDocumento,
                    Value = d.IdDocumento.ToString(),
                    Selected = false
                };

            });
            // a esos datos los agregamos a la bolsita
            ViewBag.itemsDocumento = itemsTipoDocumento;

            //Lista Deportes
            List<DeporteItemVM> listaDeportes = AD_Socios.ObtenerListaDeportes();

            List<SelectListItem> itemsDeportes = listaDeportes.ConvertAll(de =>
            {
                return new SelectListItem()
                {
                    Text = de.NombreDeporte,
                    Value = de.IdDeporte.ToString(),
                    Selected = false
                };

            });
            // a esos datos los agregamos a la bolsita
            ViewBag.itemsDeportes = itemsDeportes;



            return View();
        }

        [HttpPost]
        public ActionResult AltaSocio(Socio model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Socios.InsertarNuevoSocio(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoSocios", "Socio");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult ListadoSocios()
        {
            List<SocioItemVM> lista = AD_Socios.ObtenerListaSocios();
            return View(lista);
        }

        public ActionResult ReporteSocios()
        {
            List<DeporteItemVM> lista = AD_Socios.ObtenerReporte();
            return View(lista);
        }


    }
}