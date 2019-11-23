using ProjetoLojaVitrine.Models;
using ProjetoLojaVitrine.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.ViewsModel
{
    public class ProCatCarrListView
    {       
        public IEnumerable<Produtos> BuscarProduto { get; set; }
        public IEnumerable<Carrousel> BuscarCarrousel { get; set; }
        public string CategoriaAtual { get; set; }

    }
}