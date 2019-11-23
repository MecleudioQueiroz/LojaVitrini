using ProjetoLojaVitrine.Administrativo.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Administrativo.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string repitaSenha { get; set; }

        public Usuario BuscarPorId(int Id)
        {
            return new UsuarioRepository().BuscarPorId(Id);
        }

        //public IList<Usuario> listarNomeSenha()
        //{
        //    return new UsuarioRepository().BuscarNomeSenha();
        //}

        public IList<Usuario> listarUsuario()
        {
            IList<Usuario> listarTodos = new UsuarioRepository().ListaTodos().ToList();  
            return listarTodos;
        }

        public void Novo()
        {
            if (id == 0)
            {
                new UsuarioRepository().Insert(this);
            }
            else
            {
                new UsuarioRepository().Update(this);
            }
        }

        public void Excluir()
        {
            new UsuarioRepository().Excluir(this);
        }
    }

}