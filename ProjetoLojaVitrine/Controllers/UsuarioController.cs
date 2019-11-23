using ProjetoLojaVitrine.Administrativo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaVitrine.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult ListarUsuario(Usuario objUsuario)
        {
            return View(objUsuario.listarUsuario());
        }

        public ActionResult NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoUsuario(Usuario objUsuario)
        {
            objUsuario.Novo();
           return RedirectToAction("ListarUsuario");
        }

        public ActionResult ExcluirUsuario (int id)
        {
            return View(new Usuario().BuscarPorId(id));
        }

        [HttpPost]
        public ActionResult ExcluirUsuario(Usuario objUsuario)
        {
            objUsuario.Excluir();
            return RedirectToAction("ListarUsuario");
        }

        public ActionResult EditarUsuario(int id)
        {
            return View(new Usuario().BuscarPorId(id));
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuario objUsuario)
        {
            objUsuario.Novo();
            return RedirectToAction("ListarUsuario");
        }
    }
}