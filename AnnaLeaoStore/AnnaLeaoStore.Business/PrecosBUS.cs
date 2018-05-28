using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
    public class PrecosBUS
    {
		private PrecosREP _precosREP = new PrecosREP();
		private ListaPrecosMOD _precoMOD = new ListaPrecosMOD();

		public List<ListaPrecosMOD> GetAll()
        {
            List<ListaPrecosMOD> precos = new List<ListaPrecosMOD>();

            foreach (var item in _precosREP.GetAll())
            {
                item.DataValidadeFmt = item.Validade.ToString().Substring(1, 10);
                precos.Add(item);
            }

            return precos;

        }

		public void Deletar(int id){
			try
			{
				_precosREP.Deletar(id);

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
				return _precosREP.GetById(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public ListaPrecosMOD Insert(ListaPrecosMOD preco)
        {
            try
            {
				_precoMOD = ValidaPreco(preco);
				return _precosREP.Inserir(_precoMOD);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

		public void Update(ListaPrecosMOD preco)
        {
            try
            {
				_precoMOD = ValidaPreco(preco);
				_precosREP.Atualizar(_precoMOD);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

		public ListaPrecosMOD ValidaPreco(ListaPrecosMOD preco)
        {
            try
            {
                if (String.IsNullOrEmpty(preco.Descricao))
                {
                    throw new Exception("Preencha a Descrição da Lista de Preco!");
                }

				if (preco.Validade == null)
				{
					preco.Validade = DateTime.Now;
				}
                return preco;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
