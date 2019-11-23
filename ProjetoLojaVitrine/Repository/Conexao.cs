using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoLojaVitrine.Repository
{
    public class Conexao
    {
        public static SqlConnection Conetar()
        {
            string StrCon = ConfigurationManager.ConnectionStrings["BDLojaVitrini"].ConnectionString;
            SqlConnection con = new SqlConnection(StrCon);

            //verificar se o banco estar fechado, e irar abrir o mesmo.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            return con;
        }

        public static void Crud(SqlCommand command)
        {
            SqlConnection con = Conetar();
            command.Connection = con;
            command.ExecuteNonQuery();
            con.Close();
        }

        public static SqlDataReader Selecionar(SqlCommand comando)
        {
            SqlConnection con = Conetar();
            comando.Connection = con;
            SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
        }
    }
}