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
		private ListaPrecos _precoMOD = new ListaPrecos();

		public List<ListaPrecos> GetAll()
        {
            return _precosREP.GetAll();
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

		public ListaPrecos GetById(int id)
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

		public ListaPrecos Insert(ListaPrecos preco)
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

		public void Update(ListaPrecos preco)
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

		public ListaPrecos ValidaPreco(ListaPrecos preco)
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
