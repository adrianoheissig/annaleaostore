using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository.Extensions;

namespace AnnaLeaoStore.Repository
{
    public class ProdutosREP
    {
        private ADO _ado = new ADO();

        private string _strSQL;

        public List<ProdutosMOD> GetID()
        {
            try
            {
                _strSQL = "LISTARPRODUTOSBASICO";

                List<ProdutosMOD> produtos = new List<ProdutosMOD>();

                DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure);

                foreach (DataRow item in registros.Rows)
                {
                    produtos.Add(new ProdutosMOD
                    {
                        ID = item.GetValue<int>("ID"),
                        Descricao = item.GetText("DESCRICAO"),
                    });
                }
                return produtos;
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
                _strSQL = "DELETARPRODUTO";
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

        public void Inserir(ContatosMOD contatos)
        {
            try
            {
                string storedProcedure = "INSERIRCONTATO";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IDTIPOREDESOCIAL", contatos.IDTipoRedeSocial);
                cmd.Parameters.AddWithValue("@DESCRICAO", contatos.Descricao);
                cmd.Parameters.AddWithValue("@IDPESSOAS", contatos.IDPessoa);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(ContatosMOD contatos)
        {
            try
            {
                string storedProcedure = "ATUALIZARCONTATO";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", contatos.ID);
                cmd.Parameters.AddWithValue("@DESCRICAO", contatos.Descricao);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
