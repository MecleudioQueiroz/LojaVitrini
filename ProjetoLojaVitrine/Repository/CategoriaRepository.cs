using ProjetoLojaVitrine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Repository
{
    public class CategoriaRepository
    {
        public void Insert(Categoria ObjCategoria)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Insert Into Categoria (NomeCategoria,Descricao) Values (@NomeCategoria,@Descricao)";
            comando.Parameters.AddWithValue("@NomeCategoria", ObjCategoria.NomeCategoria);
            comando.Parameters.AddWithValue("@Descricao", ObjCategoria.Descricao);
           
            Conexao.Crud(comando);
        }

        public void Update(Categoria ObjCategoria)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Update Categoria Set NomeCategoria = @NomeCategoria, Descricao = @Descricao Where CategoriaId = @CategoriaId";
            comando.Parameters.AddWithValue("@CategoriaId", ObjCategoria.CategoriaId);
            comando.Parameters.AddWithValue("@NomeCategoria", ObjCategoria.NomeCategoria);
            comando.Parameters.AddWithValue("@Descricao", ObjCategoria.Descricao);

            Conexao.Crud(comando);
        }

        public void Excluir(Categoria ObjCategoria)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete Categoria Where CategoriaId = @CategoriaId";
            comando.Parameters.AddWithValue("@CategoriaId", ObjCategoria.CategoriaId);
            Conexao.Crud(comando);
        }

        public Categoria BuscarPorId(int id)
        {
            Categoria ObjCategoria = new Categoria();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Categoria Where CategoriaId = @CategoriaId";
            comando.Parameters.AddWithValue("@CategoriaId", id);

            SqlDataReader dr = Conexao.Selecionar(comando);


            if (dr.HasRows)
            {
                dr.Read();
                ObjCategoria.CategoriaId = Convert.ToInt32(dr["CategoriaId"]);
                ObjCategoria.NomeCategoria = dr["NomeCategoria"].ToString();
                ObjCategoria.Descricao = dr["Descricao"].ToString();
            }
            else
            {
                ObjCategoria = null;
            }
            return ObjCategoria;
        }

        public IList<Categoria> ListaTodos()
        {
            IList<Categoria> listarCategoria = new List<Categoria>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Categoria";


            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Categoria ObjCategoria = new Categoria();

                    ObjCategoria.CategoriaId = Convert.ToInt32(dr["CategoriaId"]);
                    ObjCategoria.NomeCategoria = dr["NomeCategoria"].ToString();
                    ObjCategoria.Descricao = dr["Descricao"].ToString();
                    //ObjCategoria.objProdutos = new ProdutoRepository().BuscarPorId((int)dr["ProdutoId"]);

                    listarCategoria.Add(ObjCategoria);
                }
            }
            else
            {
                listarCategoria = null;
            }
            return listarCategoria;
        }

        public IList<Categoria> BuscarPorNome(string nome)
        {
            IList<Categoria> listaNome = new List<Categoria>();

            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Categoria WHERE NomeCategoria LIKE @NomeCategoria";

            comando.Parameters.AddWithValue("@NomeCategoria", string.Format("%{0}%", nome));

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Categoria objCate = new Categoria();

                    objCate.CategoriaId = (int)dr["CategoriaId"];
                    objCate.NomeCategoria = dr["NomeCategoria"].ToString();
                    objCate.Descricao = (string)dr["descricao"];
                    //objCate.objProdutos = new ProdutoRepository().BuscarPorId((int)dr["ProdutoId"]);
                    listaNome.Add(objCate);
                }
            }
            else
            {
                listaNome = null;
            }
            return listaNome;
        }
    }
}