using ProjetoLojaVitrine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaVitrine.Controllers
{
    public class CategoriaController : Controller
    {
       

        public ActionResult Listar(Categoria objCate)
        {
            return View(objCate.ListarCategoria());
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Categoria objCate)
        {
            objCate.Novo();
            return RedirectToAction("Listar");
        }

        public ActionResult ExcluirCategoria(int CategoriaId)
        {         
            return View(new Categoria().BuscarPorId(CategoriaId));
        }

        [HttpPost]
        public ActionResult ExcluirCategoria(Categoria categoria)
        {
            categoria.ExcluirCategoria();
            return RedirectToAction("Listar");
        }

        public ActionResult EditarCategoria(int CategoriaId)
        {
            return View(new Categoria().BuscarPorId(CategoriaId));
        }

        [HttpPost]
        public ActionResult EditarCategoria(Categoria categoria)
        {
            categoria.Novo();
            return RedirectToAction("Listar");
        }
    }
}