using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository.Extensions;

namespace AnnaLeaoStore.Repository
{
    public class ProdutosREP
    {
        private ADO _ado = new ADO();

		private DBContext db = new DBContext();

        private string _strSQL;

		public List<Produtos> GetAll()
        {
            try
            {
				/* _strSQL = "LISTARPRODUTOSBASICO";

				 List<Produtos> produtos = new List<Produtos>();

				 DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure);

				 foreach (DataRow item in registros.Rows)
				 {
					 produtos.Add(new Produtos
					 {
						 ID = item.GetValue<int>("ID"),
						 ReferId = item.GetText("REFERID"),
						 Descricao = item.GetText("DESCRICAO"),
						 Cor = item.GetText("COR"),
						 Pessoas = new Pessoas { Nome = item.GetText("NOME") },
						 DescricaoSituacao = item.GetText("DESC_SITUACAO"),
						 DataUltimaCompra = item.GetValue<DateTime>("DATAULTIMACOMPRA"),
						 QtdeEstoque = item.GetValue<decimal>("QTDE_ESTOQUE")
					 });
				 } */

				return db.ProdutosMOD.ToList();
                
                //return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Produtos GetById(int id)
        {
            try
            {
				/*_strSQL = "LISTARPRODUTOPORID";

                Produtos produto = new Produtos();

                DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure,"@ID",id);

                foreach (DataRow item in registros.Rows)
                {
                    produto.ReferId = item.GetText("REFERID");
                    produto.Descricao = item.GetText("DESCRICAO");
                    produto.Cor = item.GetText("COR");
					produto.Grade = new Grade{ ID = item.GetValue<int>("IDGRADE"), Descricao = item.GetText("DESCRICAOGRADE")};
					produto.Pessoas = new Pessoas { ID = item.GetValue<int>("IDFORNECEDOR"), Nome = item.GetText("NOME") };
                    produto.Ativo = item.GetBool("ATIVO");
                    produto.Observacao = item.GetText("OBSERVACAO");
                    produto.LinkProduto = item.GetText("LINKPRODUTO");
                } */

				return db.ProdutosMOD.Find(id);

                //return produto;
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

		public void Inserir(Produtos produto)
        {
            try
            {
				/*	string storedProcedure = "INSERIRPRODUTO";
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
					*/
				db.ProdutosMOD.Add(produto);
				db.SaveChanges();
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public void Atualizar(Produtos produto)
        {
            try
            {
				/* string storedProcedure = "ATUALIZARPRODUTO";
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
				 */
				Produtos produtoOri = new Produtos();
				produtoOri = db.ProdutosMOD.Find(produto.ID);

				produtoOri.ReferId = produto.ReferId;
				produtoOri.Descricao = produto.Descricao;
				produtoOri.Cor = produto.Cor;
				produtoOri.Grades.ID = produto.Grades.ID;
				produtoOri.Pessoas.ID = produto.Pessoas.ID;
				produtoOri.Situacao = produto.Situacao;
				produtoOri.Observacao = produto.Observacao;
				produtoOri.LinkProduto = produto.LinkProduto;

				db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
