using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ProjetoLojaVitrine.Administrativo.Models;
using ProjetoLojaVitrine.Repository;

namespace ProjetoLojaVitrine.Administrativo.Repository
{
    public class UsuarioRepository
    {
        public void Insert(Usuario ObjUsuario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Insert Into Usuario (Nome,Senha,RepitaSenha) values (@Nome, @Senha, @RepitaSenha)";
            comando.Parameters.AddWithValue("@Nome", ObjUsuario.Nome);
            comando.Parameters.AddWithValue("@Senha", ObjUsuario.Senha);
            comando.Parameters.AddWithValue("@RepitaSenha", ObjUsuario.repitaSenha);
            Conexao.Crud(comando);
        }

        public void Update(Usuario objUsuario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "update Usuario set Nome = @nome, Senha = @Senha, RepitaSenha = @RepitaSenha where Id = @Id";
            comando.Parameters.AddWithValue("@Id", objUsuario.id);
            comando.Parameters.AddWithValue("@Nome", objUsuario.Nome);
            comando.Parameters.AddWithValue("@Senha", objUsuario.Senha);
            comando.Parameters.AddWithValue("@RepitaSenha", objUsuario.repitaSenha);
            Conexao.Crud(comando);
        }

        public void Excluir(Usuario objUsuario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete Usuario Where Id = @Id";
            comando.Parameters.AddWithValue("@Id", objUsuario.id);
            Conexao.Crud(comando);
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario objUsuario = new Usuario();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Usuario Where Id = @Id";
            comando.Parameters.AddWithValue("@Id", id);

            SqlDataReader dr = Conexao.Selecionar(comando);


            if (dr.HasRows)
            {
                dr.Read();
                objUsuario.id = Convert.ToInt32(dr["Id"]);
                objUsuario.Nome = dr["Nome"].ToString();
                objUsuario.Senha = dr["Senha"].ToString();
                objUsuario.repitaSenha = dr["RepitaSenha"].ToString();               
            }
            else
            {
                objUsuario = null;
            }
            return objUsuario;
        }

        public IList<Usuario> ListaTodos()
        {
            IList<Usuario> listarUsuario = new List<Usuario>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Usuario";


            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();

                    objUsuario.id = Convert.ToInt32(dr["Id"]);
                    objUsuario.Nome = dr["Nome"].ToString();
                    objUsuario.Senha = dr["Senha"].ToString();
                    objUsuario.repitaSenha = dr["RepitaSenha"].ToString();

                    listarUsuario.Add(objUsuario);
                }
            }
            else
            {
                listarUsuario = null;
            }
            return listarUsuario;
        }

        public Usuario BuscarNomeSenha(string Nome, string Senha)
        {
            Usuario objUsuario = new Usuario();

            objUsuario.Nome = Nome;
            objUsuario.Senha = Senha;

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuario WHERE Nome = @Nome and Senha = @Senha";
            comando.Parameters.AddWithValue("@Nome", objUsuario.Nome);
            comando.Parameters.AddWithValue("@Senha", objUsuario.Senha);
            SqlDataReader dr = Conexao.Selecionar(comando);


            if (dr.HasRows)
            {
                dr.Read();
                objUsuario.id = Convert.ToInt32(dr["Id"]);
                objUsuario.Nome = dr["Nome"].ToString();
                objUsuario.Senha = dr["Senha"].ToString();
                objUsuario.repitaSenha = dr["RepitaSenha"].ToString();
            }
            else
            {
                objUsuario = null;
            }
            return objUsuario;
        }

    }
}