using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaVitrine.Controllers
{
    public class AdministrativoController : Controller
    {
      
        public ActionResult HomeAdm()
        {

            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Login/Login");
            }
        }
    }
}