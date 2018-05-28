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

		public List<ProdutosMOD> GetAll()
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
                        ReferId = item.GetText("REFERID"),
                        Descricao = item.GetText("DESCRICAO"),
                        Cor = item.GetText("COR"),
                        Pessoas = new PessoasMOD { Nome = item.GetText("NOME") },
                        DescricaoSituacao = item.GetText("DESC_SITUACAO"),
                        DataUltimaCompra = item.GetValue<DateTime>("DATAULTIMACOMPRA"),
                        QtdeEstoque = item.GetValue<decimal>("QTDE_ESTOQUE")
                    });
                }
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ProdutosMOD GetById(int id)
        {
            try
            {
                _strSQL = "LISTARPRODUTOPORID";

                ProdutosMOD produto = new ProdutosMOD();

                DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure,"@ID",id);

                foreach (DataRow item in registros.Rows)
                {
                    produto.ReferId = item.GetText("REFERID");
                    produto.Descricao = item.GetText("DESCRICAO");
                    produto.Cor = item.GetText("COR");
					produto.Grade = new GradeMOD{ ID = item.GetValue<int>("IDGRADE"), Descricao = item.GetText("DESCRICAOGRADE")};
					produto.Pessoas = new PessoasMOD { ID = item.GetValue<int>("IDFORNECEDOR"), Nome = item.GetText("NOME") };
                    produto.Ativo = item.GetBool("ATIVO");
                    produto.Observacao = item.GetText("OBSERVACAO");
                    produto.LinkProduto = item.GetText("LINKPRODUTO");
                }
                return produto;
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

		public void Inserir(ProdutosMOD produtos)
        {
            try
            {
				string storedProcedure = "INSERIRPRODUTO";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@REFERID", produtos.ReferId);
				cmd.Parameters.AddWithValue("@DESCRICAO", produtos.Descricao);
				cmd.Parameters.AddWithValue("@COR", produtos.Cor);
				cmd.Parameters.AddWithValue("@IDGRADE", produtos.Grade.ID);
				cmd.Parameters.AddWithValue("@IDFORNECEDOR", produtos.Pessoas.ID);
				cmd.Parameters.AddWithValue("@SITUACAO", produtos.Situacao);
				cmd.Parameters.AddWithValue("@OBSERVACAO", produtos.Observacao, null);
				cmd.Parameters.AddWithValue("@LINKPRODUTO", produtos.LinkProduto, null);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public void Atualizar(ProdutosMOD produtos)
        {
            try
            {
                string storedProcedure = "ATUALIZARPRODUTO";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@ID", produtos.ID);
				cmd.Parameters.AddWithValue("@REFERID", produtos.ReferId);
                cmd.Parameters.AddWithValue("@DESCRICAO", produtos.Descricao);
                cmd.Parameters.AddWithValue("@COR", produtos.Cor);
                cmd.Parameters.AddWithValue("@IDGRADE", produtos.Grade.ID);
                cmd.Parameters.AddWithValue("@IDFORNECEDOR", produtos.Pessoas.ID);
                cmd.Parameters.AddWithValue("@SITUACAO", produtos.Situacao);
				cmd.Parameters.AddWithValue("@OBSERVACAO", produtos.Observacao, null);
				cmd.Parameters.AddWithValue("@LINKPRODUTO", produtos.LinkProduto, null);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
