using ProjetoLojaVitrine.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
     
        public IEnumerable<Produtos> ListaDeProdutos { get; set; }
        public Produtos objProdutos { get; set; }

        public Categoria BuscarPorId(int id)
        {
            return new CategoriaRepository().BuscarPorId(id);
        }

        public IList<Categoria>ListarCategoria()
        {
            IList<Categoria> ListarTodos = new CategoriaRepository().ListaTodos();
            return ListarTodos;
        }

        public void Novo()
        {
            if (CategoriaId == 0)
            {
                new CategoriaRepository().Insert(this);
            }
            else
            {
                new CategoriaRepository().Update(this);
            }
        }

        public void ExcluirCategoria()
        {
            new CategoriaRepository().Excluir(this);
        }
    }
}