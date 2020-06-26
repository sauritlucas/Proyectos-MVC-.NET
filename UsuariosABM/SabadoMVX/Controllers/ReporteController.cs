using SabadoMVX.ViewModels.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabadoMVX.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            InfoGralVM resultado = new InfoGralVM();
            return View(resultado);
        }
    }
}