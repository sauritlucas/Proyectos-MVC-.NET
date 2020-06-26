using SabadoMVX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SabadoMVX.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario modelo)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Principal", "Home");
            }
            else { return View(modelo); }
        }
    }
}