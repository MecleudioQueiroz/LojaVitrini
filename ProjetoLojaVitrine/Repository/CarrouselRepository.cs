using ProjetoLojaVitrine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoLojaVitrine.Repository
{
    public class CarrouselRepository
    {
        public void Insert(Carrousel objCa)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Insert Into Carrousel (Descricao, ImagePah) values(@Descricao,@ImagePah)";
            comando.Parameters.AddWithValue("@Descricao", objCa.Descricao);
            comando.Parameters.AddWithValue("@ImagePah", objCa.ImagePah);
            Conexao.Crud(comando);
        }

        public void Update(Carrousel objca)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Update Carrousel Set Descricao = @Descricao, ImagePah = @ImagePah where Id = @Id";
            comando.Parameters.AddWithValue("@Id", objca.Id);
            comando.Parameters.AddWithValue("@Descricao", objca.Descricao);
            comando.Parameters.AddWithValue("@ImagePah", objca.ImagePah);
            Conexao.Crud(comando);
        }

        public void Delete(Carrousel objca)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " Delete Carrousel Where Id = @Id";
            comando.Parameters.AddWithValue("@Id", objca.Id);
            Conexao.Crud(comando);
        }

        public Carrousel BuscarPorId(int id)
        {
            Carrousel ObjCarrousel = new Carrousel();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * From Carrousel Where Id = @Id";
            comando.Parameters.AddWithValue("@Id", id);

            SqlDataReader dr = Conexao.Selecionar(comando);


            if (dr.HasRows)
            {
                dr.Read();
                ObjCarrousel.Id = Convert.ToInt32(dr["Id"]);
                ObjCarrousel.Descricao = dr["Descricao"].ToString();
                ObjCarrousel.ImagePah = dr["ImagePah"].ToString();
               
            }
            else
            {
                ObjCarrousel = null;
            }
            return ObjCarrousel;
        }

        public IList<Carrousel>ListarTodos()
        {
            IList<Carrousel> ListarCarrousel = new List<Carrousel>();
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Carrousel";

            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Carrousel objCa = new Carrousel();
                    objCa.Id = Convert.ToInt32(dr["Id"]);
                    objCa.Descricao = dr["Descricao"].ToString();
                    objCa.ImagePah = dr["ImagePah"].ToString();

                    ListarCarrousel.Add(objCa);
                }
            }
            else
            {
                ListarCarrousel = null;
            }
            return ListarCarrousel;
        }
    }
}