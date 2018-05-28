using AnnaLeaoStore.Business.Interfaces;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Business
{
	public class ProdutosBUS
    {
		private ProdutosREP _produtosRep = new ProdutosREP();

		private ProdutosMOD _produtosMOD = new ProdutosMOD();

		public void Delete(int id)
        {
            try
            {
				_produtosRep.Deletar(id);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

		public List<ProdutosMOD> GetAll()
        {
			try
			{
				return _produtosRep.GetAll();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

        }

		public ProdutosMOD GetByID(int id)
        {
			try
			{
				return _produtosRep.GetById(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Insert(ProdutosMOD produtos)
        {
            try
            {
				_produtosMOD = ValidaProduto(produtos);
				_produtosRep.Inserir(_produtosMOD);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

		public void Update(ProdutosMOD produtos)
        {
            try
            {
				_produtosMOD = ValidaProduto(produtos);
				_produtosRep.Atualizar(_produtosMOD);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

		public ProdutosMOD ValidaProduto(ProdutosMOD produto)
        {
            try
            {
				if (String.IsNullOrEmpty(produto.ReferId))
                {
                    throw new Exception("Preencha o Código de Referência para o Produto!");
                }
				if (String.IsNullOrEmpty(produto.Descricao))
                {
                    throw new Exception("Preencha a Descrição do Produto!");
                }
				if (String.IsNullOrEmpty(produto.Cor))
                {
                    throw new Exception("Preencha a Cor do Produto!");
                }

                produto.Situacao = produto.Ativo ? 1 : 0;

				return produto;


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
