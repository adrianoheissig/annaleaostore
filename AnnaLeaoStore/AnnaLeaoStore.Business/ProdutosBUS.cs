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
			return null;
        }

		public void Insert(ProdutosMOD produtos)
        {
            try
            {
				_produtosRep.Inserir(produtos);

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
				_produtosRep.Atualizar(produtos);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public PessoasMOD ValidaPessoa(PessoasMOD pessoa)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoa.Nome))
                {
                    throw new Exception("Nome não pode ser Em Branco!");
                }

                pessoa.Situacao = pessoa.Ativo ? 1 : 0;

                return pessoa;


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
