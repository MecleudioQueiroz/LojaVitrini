using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjetoLojaVitrine.Administrativo.Models;
using ProjetoLojaVitrine.Administrativo.Repository;

namespace ProjetoLojaVitrine.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login( )
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string Nome, string Senha, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            UsuarioRepository objrep = new UsuarioRepository();
            var query = objrep.BuscarNomeSenha(Nome, Senha);

            if (ModelState.IsValid)
            {         
                if (query != null)
                {
                    Session["Id"] = query.id.ToString();
                    Session["Nome"] = query.Nome.ToString();
                    return Redirect("/Administrativo/HomeAdm");
                }
                else
                {
                    ViewBag.Erro = "Usuario Senha Incorreta";
                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction( "Login" );
        }
    }
}