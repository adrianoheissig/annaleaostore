using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Para acessar os métodos e propriedades do banco, usamos as namespace DATA E SQLCLIENT
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Data.Common;

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


		public DataTable RetornarTabela(String sql, CommandType cmd, params object[] parametros)
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

                    comando.CommandType = cmd;

                    comando.Connection = conexao;

					if (parametros.Length > 0)
                    {
                        for (int i = 0; i < parametros.Length; i += 2)
                        {
                            comando.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = comando;

                        da.Fill(tabela);

                    }

                }

            }

            return tabela;
        }

        #region DataBase-Helper

		public DbCommand ObterCommand(string sql, params object[] parametros)
        {
            var cn = new SqlConnection(_strConn);
            var cmd = new SqlCommand();

            cmd.CommandText = sql;
            cmd.Connection = cn;

            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }

            return cmd;

        }

        public DbCommand ObterCommand(SqlCommand cmd)
        {
            var cn = new SqlConnection(_strConn);
            cmd.Connection = cn;
            return cmd;
        }


        public DbDataReader ObterDataReader(DbCommand cmd)
        {

            try
            {
                cmd.Connection.Open();

                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;

            }
            catch (Exception)
            {

                throw;

            }

        }

        public bool VerificaExiste(DbCommand cmd)
        {
            try
            {
                cmd.Connection.Open();

                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void ExecutarSql(DbCommand cmd)
        {
            try
            {
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        #endregion

    }
}
