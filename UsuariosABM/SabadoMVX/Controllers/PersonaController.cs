using SabadoMVX.AccesoDeDatos;
using SabadoMVX.Models;
using SabadoMVX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabadoMVX.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult DatosPersona(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Personas.ObtenerListaSexos();
            // este de aca se utiliza para poder luego cargar la info en un combo
            List<SelectListItem> itemsCombo = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };

            });

            Persona resultado = AD_Personas.ObtenerPersona(idPersona);

            foreach (var item in itemsCombo)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.items = itemsCombo;

            ViewBag.Nombre = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult DatosPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.ActualizarDatosPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }

            return View();
        }

        



        public ActionResult AltaPersona()
        {
            List<SexoItemVM> listaSexos = AD_Personas.ObtenerListaSexos();
            // este de aca se utiliza para poder luego cargar la info en un combo
            List<SelectListItem> items = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };

            });
            // a esos datos los agregamos a la bolsita
            ViewBag.items = items;

            return View();
        }
       [HttpPost]
       public ActionResult AltaPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.InsertarNuevaPersona(model);
                if (resultado)
                {
                   return RedirectToAction("ListadoPersonas", "Persona");
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

        public ActionResult ListadoPersonas()
        {
            List<Persona> lista = AD_Personas.ObtenerListaPersonas();
            return View(lista);
        }

        // Listado Persona Inactiva
        public ActionResult ListadoPersonasInactivas()
        {
            List<Persona> lista = AD_Personas.ObtenerListaPersonasInactivas();
            return View(lista);
        }



        public ActionResult EliminarPersona(int idPersona)
        {

            Persona resultado = AD_Personas.ObtenerPersona(idPersona);
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.EliminarPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonas", "Persona");
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

        // Modificar Persona Inactiva
        public ActionResult DatosPersonaInactiva(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Personas.ObtenerListaSexos();
            // este de aca se utiliza para poder luego cargar la info en un combo
            List<SelectListItem> itemsCombo = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };

            });

            Persona resultado = AD_Personas.ObtenerPersonaInactiva(idPersona);

            foreach (var item in itemsCombo)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.items = itemsCombo;

            ViewBag.Nombre = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult DatosPersonaInactiva(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.ActualizarDatosPersonaInactiva(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonasInactivas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }

            return View();
        }

        // Alta Persona Inactiva
        public ActionResult AltaPersonaInactiva(int idPersona)
        {
            List<SexoItemVM> listaSexos = AD_Personas.ObtenerListaSexos();
            // este de aca se utiliza para poder luego cargar la info en un combo
            List<SelectListItem> itemsCombo = listaSexos.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };

            });

            Persona resultado = AD_Personas.ObtenerPersonaInactiva(idPersona);

            foreach (var item in itemsCombo)
            {
                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.items = itemsCombo;

            ViewBag.Nombre = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        }
        [HttpPost]
        public ActionResult AltaPersonaInactiva(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.AltaPersonaInactiva(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersonasInactivas", "Persona");
                }
                else
                {
                    return View(model);
                }
            }

            return View();
        }
    }
}