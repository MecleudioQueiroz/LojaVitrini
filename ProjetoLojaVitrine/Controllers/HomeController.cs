using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoLojaVitrine.Models;
using ProjetoLojaVitrine.ViewsModel;

namespace ProjetoLojaVitrine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ProCatCarrListView viewModel)
        {        
            Carrousel c = new Carrousel();
            Produtos p = new Produtos();
            viewModel.BuscarCarrousel = c.ListarTodos().ToList();
            viewModel.BuscarProduto = p.listaProdutos().ToList();
            return View (viewModel);    
        }

      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}