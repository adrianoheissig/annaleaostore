using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class ProdutosREP
    {
		private DBContext db = new DBContext();

		public List<Produtos> GetAll()
        {
            try
            {
                return db.ProdutosMOD.ToList();
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
				return db.ProdutosMOD.Find(id);
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
                var produto = db.ProdutosMOD.Find(id);
                db.ProdutosMOD.Remove(produto);
                db.SaveChanges();
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
