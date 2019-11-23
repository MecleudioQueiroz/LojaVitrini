using ProjetoLojaVitrine.Models;
using ProjetoLojaVitrine.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaVitrine.Controllers
{
    public class CarrouselController : Controller
    {

       public ActionResult ListarCarrousel(Carrousel carrousel)
        {
            return View(carrousel.ListarTodos());
        }
        public ActionResult Novo( )
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Carrousel objCa)
        {
            //Metodos para uploand da imagem 
            string fileName = Path.GetFileNameWithoutExtension(objCa.Imagefile.FileName);
            string extencion = Path.GetExtension(objCa.Imagefile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmsfff") + extencion;
            objCa.ImagePah = "/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/images/"), fileName);
            objCa.Imagefile.SaveAs(fileName);

            objCa.Novo();
            return RedirectToAction("ListarCarrousel");
        }

        public ActionResult ExcluirCarrousel(int Id)
        {
           
            return View(new Carrousel().BuscarPorId(Id));
        }

        [HttpPost]
        public ActionResult ExcluirCarrousel(Carrousel Carro)
        {
            Carro.ExcluirCarrousel();
            return RedirectToAction("ListarCarrousel");
        }
     
    }
}