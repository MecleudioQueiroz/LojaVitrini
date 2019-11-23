using ProjetoLojaVitrine.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Models
{
    public class Carrousel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public  string ImagePah { get; set; }

        public HttpPostedFileBase Imagefile { get; set; }
        public Carrousel objCa { get; set; }

        public Carrousel BuscarPorId(int Id)
        {
            return new CarrouselRepository().BuscarPorId(Id);
        }

        public IList<Carrousel>ListarTodos()
        {
            IList<Carrousel> listar = new List<Carrousel>();
            listar =   new CarrouselRepository().ListarTodos();
            return listar;
        }

        public void Novo()
        {
            if (Id == 0)
            {
                new CarrouselRepository().Insert(this);
            }
            else
            {
                new CarrouselRepository().Update(this);
            }
        }

        public void ExcluirCarrousel()
        {
            new CarrouselRepository().Delete(this);
        }
    }
}