using ProjetoLojaVitrine.Models;
using ProjetoLojaVitrine.Repository;
using ProjetoLojaVitrine.ViewsModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaVitrine.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepository produtoRep = new ProdutoRepository();
        private CategoriaRepository cateRep = new CategoriaRepository();


        //Listar todos Produtos da classe produtos
        public ActionResult ListarProdutos(Produtos ObjProdutos)
        {
            return View(ObjProdutos.listaProdutos());
        }

        public ActionResult ListarPorCategoria(string categoria)
        {
            Categoria objca = new Categoria();
            Produtos objP = new Produtos();

            string _categoria = categoria;
            IEnumerable<Produtos> produtos;
            string categoriaatual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = objP.listaProdutos();
                categoriaatual = "All produtos";
            }
            else
            {
                if (string.Equals(objca.NomeCategoria, _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    produtos = objP.Categoria.ListaDeProdutos.Where(p => p.Categoria.Equals(objca.NomeCategoria)).OrderBy(p => p.Nome);
                }
                else
                {
                    produtos = objP.Categoria.ListaDeProdutos.Where(p => p.Categoria.Equals(objca.NomeCategoria)).OrderBy(p => p.Nome);
                    categoriaatual = _categoria;
                }


            }
            return View(new ProCatCarrListView
            {
                BuscarProduto = produtos,
                CategoriaAtual = categoriaatual
            
            });
        }

        public ActionResult NovoProduto()
        {           
            ViewBag.CategoriaId = new SelectList(cateRep.BuscarPorNome(""), "CategoriaId","NomeCategoria");
            return View();
        }

        //Metodo Post para cadastrar novo produto
        [HttpPost]
        public ActionResult NovoProduto(Produtos objProduto)
        {         
            //Metodos para uploand da imagem 
            string fileName = Path.GetFileNameWithoutExtension(objProduto.Imagefile.FileName);
            string extencion = Path.GetExtension(objProduto.Imagefile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmsfff") + extencion;
            objProduto.ImagemUrl = "/images/" + fileName;                
            fileName = Path.Combine(Server.MapPath("/images/"), fileName);
            objProduto.Imagefile.SaveAs(fileName);

            objProduto.Novo();

            //var result = "Produto Add com Sucesso!!";
            //return Json(result, JsonRequestBehavior.AllowGet);

            return RedirectToAction("ListarProdutos");
        }

        public ActionResult Detalhe(int ProdutoId)
        {
            return View(new Produtos().buscarPorId(ProdutoId));
        }

        public ActionResult EditarProduto(int produtoId)
        {
            ViewBag.CategoriaId = new SelectList(cateRep.BuscarPorNome(""), "CategoriaId", "NomeCategoria");
            Produtos p = produtoRep.BuscarPorId(produtoId);
            Categoria c = cateRep.BuscarPorId(produtoId);        
           
            return View(p);
        }

        [HttpPost]
        public ActionResult EditarProduto(Produtos produtos)
        {
            //Metodos para uploand da imagem 
            string fileName = Path.GetFileNameWithoutExtension(produtos.Imagefile.FileName);
            string extencion = Path.GetExtension(produtos.Imagefile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmsfff") + extencion;
            produtos.ImagemUrl = "/images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/images/"), fileName);
            produtos.Imagefile.SaveAs(fileName);

            produtoRep.Update(produtos);
            return RedirectToAction("ListarProdutos");
        }

        public ActionResult ExcluirProduto(int produtoId)
        {
            Produtos p = produtoRep.BuscarPorId(produtoId);
            return View(p);
        }

        [HttpPost]
        public ActionResult ExcluirProduto(Produtos produtos)
        {
            produtos.Excluir();
            return PartialView(produtos);
        }
      
    }
}