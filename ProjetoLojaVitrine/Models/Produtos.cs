using ProjetoLojaVitrine.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Models
{
    public class Produtos
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }     
        public int CategoriaId { get; set; }
     
        public HttpPostedFileBase Imagefile { get; set; }

        //Relaciomento da tabela do banco em um pra muitos
        public virtual Categoria Categoria { get; set; }

        //Metodo para buscar produto pelo Id do produto.
        public Produtos buscarPorId(int id)
        {
           return new ProdutoRepository().BuscarPorId(id);
            
        }

        public IList<Produtos>listaProdutos()
        {
            IList<Produtos> listarTodos = new ProdutoRepository().ListaTodos().OrderBy(p => p.ProdutoId).ToList();
            return listarTodos;
        }

        public void Novo()
        {
            if (ProdutoId == 0)
            {
                new ProdutoRepository().Insert(this);
            }
            else
            {
                new ProdutoRepository().Update(this);
            }
        }

        public void Excluir()
        {
            new ProdutoRepository().Excluir(this);
        }
    }
}