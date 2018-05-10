using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Para acessar os métodos e propriedades do banco, usamos as namespace DATA E SQLCLIENT
using System.Data;
using System.Data.SqlClient;

using System.Configuration;

namespace AnnaLeaoStore.DataAccess
{
    public class ADO
    {
        //Criamos uma variavel que vai armazenar a string de Conexao com o Banco
        private String _strConn = @"Data Source=den1.mssql6.gear.host;Initial Catalog=annaleaostoredb;User ID=annaleaostoredb;Password=Jb0ME--z3j5x;";

        //private String _strConn = ConfigurationManager.ConnectionStrings["TstConnection"].ConnectionString;

        public void ExecutarComando(String sql)
        {
            using (SqlConnection conexao = new SqlConnection())
            {
                //SqlConnection -> conecta e abre a base de dados
                conexao.ConnectionString = _strConn;
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandText = sql;
                    comando.CommandType = CommandType.Text;
                    comando.Connection = conexao;
                    //Para ser executado no Banco/Tabela precisamos chamar o metodo ExecuteNonQuery
                    comando.ExecuteNonQuery();
                }

            }
        }


        public DataTable RetornarTabela(String sql)
        {
            /*DataTable -> é um Objeto do DataSet que contem um conjunto de informações 
                           em linhas e colunas(tabela em memoria) */

            DataTable tabela = new DataTable();

            using (var conexao = new SqlConnection())
            {

                conexao.ConnectionString = _strConn;

                conexao.Open();

                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandText = sql;

                    comando.CommandType = CommandType.Text;

                    comando.Connection = conexao;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = comando;

                        da.Fill(tabela);

                    }

                }

            }

            return tabela;
        }

    }
}
