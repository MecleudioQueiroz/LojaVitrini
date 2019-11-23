using ProjetoLojaVitrine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Repository
{
    public class ProdutoRepository
    {
        public void Insert(Produtos ObjProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Insert Into Produtos (nome,DescricaoCurta,DescricaoLonga,Preco,ImagemUrl,CategoriaId) Values (@nome,@DescricaoCurta,@DescricaoLonga,@Preco,@ImagemUrl,@CategoriaId)";
            comando.Parameters.AddWithValue("@nome", ObjProduto.Nome);
            comando.Parameters.AddWithValue("@DescricaoCurta", ObjProduto.DescricaoCurta);
            comando.Parameters.AddWithValue("@DescricaoLonga", ObjProduto.DescricaoLonga);
            comando.Parameters.AddWithValue("@Preco", ObjProduto.Preco);
            comando.Parameters.AddWithValue("@ImagemUrl",ObjProduto.ImagemUrl);                 
            comando.Parameters.AddWithValue("@CategoriaId",ObjProduto.Categoria.CategoriaId);

            Conexao.Crud(comando);
        }

        public void Update(Produtos ObjProduto)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Update Produtos Set nome = @nome, DescricaoCurta = @DescricaoCurta, DescricaoLonga = @DescricaoLonga, Preco = @Preco, ImagemUrl = @ImagemUrl, CategoriaId = @CategoriaId Where ProdutoId = @ProdutoId";
            comando.Parameters.AddWithValue("@ProdutoId", ObjProduto.ProdutoId);
            comando.Parameters.AddWithValue("@nome", ObjProduto.Nome);
            comando.Parameters.AddWithValue("@DescricaoCurta", ObjProduto.DescricaoCurta);
            comando.Parameters.AddWithValue("@DescricaoLonga", ObjProduto.DescricaoLonga);
            comando.Parameters.AddWithValue("@Preco", ObjProduto.Preco);
            comando.Parameters.AddWithValue("@ImagemUrl", ObjProduto.ImagemUrl);
            comando.Parameters.AddWithValue("@CategoriaId", ObjProduto.CategoriaId);

            Conexao.Crud(comando);
        }

        public void Excluir(Produtos ObjProdutos)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Delete Produtos Where ProdutoId = @ProdutoId";
            comando.Parameters.AddWithValue("@ProdutoId", ObjProdutos.ProdutoId);
            Conexao.Crud(comando);
        }

        public Produtos BuscarPorId(int id)
        {
            Produtos ObjProdutos = new Produtos();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Produtos Where ProdutoId = @ProdutoId";
            comando.Parameters.AddWithValue("@ProdutoId", id);

            SqlDataReader dr = Conexao.Selecionar(comando);


            if (dr.HasRows)
            {
                dr.Read();
                ObjProdutos.ProdutoId = Convert.ToInt32(dr["ProdutoId"]);
                ObjProdutos.Nome = dr["nome"].ToString();
                ObjProdutos.DescricaoCurta = dr["DescricaoCurta"].ToString();
                ObjProdutos.DescricaoLonga = dr["DescricaoLonga"].ToString();
                ObjProdutos.Preco = Convert.ToDecimal( dr["Preco"]);
                ObjProdutos.ImagemUrl = dr["ImagemUrl"].ToString();
                ObjProdutos.Categoria = new CategoriaRepository().BuscarPorId((int)dr["CategoriaId"]);
            }
            else
            {
                ObjProdutos = null;
            }
            return ObjProdutos;
        }

        public IList<Produtos> ListaTodos()
        {
            IList<Produtos> listarProdutos = new List<Produtos>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Produtos";


            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Produtos ObjProdutos = new Produtos();

                    ObjProdutos.ProdutoId = Convert.ToInt32(dr["ProdutoId"]);
                    ObjProdutos.Nome = dr["nome"].ToString();
                    ObjProdutos.DescricaoCurta = dr["DescricaoCurta"].ToString();
                    ObjProdutos.DescricaoLonga = dr["DescricaoLonga"].ToString();
                    ObjProdutos.Preco = Convert.ToDecimal(dr["Preco"]);
                    ObjProdutos.ImagemUrl = dr["ImagemUrl"].ToString();
                    ObjProdutos.Categoria = new CategoriaRepository().BuscarPorId((int)dr["CategoriaId"]);

                    listarProdutos.Add(ObjProdutos);
                }
            }
            else
            {
                listarProdutos = null;
            }
            return listarProdutos;
        }
    }
}