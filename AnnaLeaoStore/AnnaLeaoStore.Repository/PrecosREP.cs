using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository.Extensions;

namespace AnnaLeaoStore.Repository
{
    public class PrecosREP
    {
        private ADO _ado = new ADO();

        private string _strSQL;

		public List<ListaPrecosMOD> GetAll()
        {
            try
            {
				_strSQL = "LISTARPRECOS";

                List<ListaPrecosMOD> precos = new List<ListaPrecosMOD>();

                DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure);

                foreach (DataRow item in registros.Rows)
                {
                    precos.Add(new ListaPrecosMOD
                    {
                        ID = item.GetValue<int>("ID"),
                        Descricao = item.GetText("DESCRICAO"),
						Validade = item.GetValue<DateTime>("VALIDADE"),
						DataValidadeFmt = item.GetValue<DateTime>("VALIDADE").ToString()
                    });
                }
                return precos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ListaPrecosMOD GetById(int id)
        {
            try
            {
                _strSQL = "LISTARPRECOPORID";

                ListaPrecosMOD preco = new ListaPrecosMOD();

                DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure,"@ID",id);

                foreach (DataRow item in registros.Rows)
                {
                    preco.Descricao = item.GetText("DESCRICAO");
					preco.Validade = item.GetValue<DateTime>("VALIDADE");
					preco.DataValidadeFmt = preco.Validade.ToString().Substring(1,10);
                }
                return preco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Deletar(int id)
        {
            try
            {
                _strSQL = "DELETARPRECO";
                var cmd = new SqlCommand(_strSQL);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public ListaPrecosMOD Inserir(ListaPrecosMOD precos)
        {
            try
            {
				string storedProcedure = "INSERIRPRECO";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

				SqlParameter outPutVal = new SqlParameter("@NOVOID", SqlDbType.Int);
                outPutVal.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outPutVal);
				cmd.Parameters.AddWithValue("@DESCRICAO", precos.Descricao);
				cmd.Parameters.AddWithValue("@VALIDADE", precos.Validade);
                
                _ado.ExecutarSql(_ado.ObterCommand(cmd));

				if (outPutVal.Value != DBNull.Value) precos.ID = Convert.ToInt32(outPutVal.Value);

				return precos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public void Atualizar(ListaPrecosMOD precos)
        {
            try
            {
                string storedProcedure = "ATUALIZARPRECO";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@ID", precos.ID);
				cmd.Parameters.AddWithValue("@DESCRICAO", precos.Descricao);
				cmd.Parameters.AddWithValue("@VALIDADE", precos.Validade);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
