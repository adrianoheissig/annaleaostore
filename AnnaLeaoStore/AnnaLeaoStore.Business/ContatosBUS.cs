using System;
using System.Collections.Generic;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
	public class ContatosBUS
    {
		private ContatosREP _contatosREP = new ContatosREP();
       
		public List<ContatosMOD> GetID(int id)
        {
			return _contatosREP.GetID(id);
        }

		public void Deletar(int id){
			try
			{
				_contatosREP.Deletar(id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public void Inserir(IEnumerable<ContatosMOD> contatos){
			try
			{

                foreach (var contato in contatos)
                {
                    if (contato.ID != null && String.IsNullOrEmpty(contato.Descricao))
                    {
                        Deletar(Convert.ToInt32(contato.ID));
                    }

                    if (contato.ID == null && !String.IsNullOrEmpty(contato.Descricao))
                    {
                        _contatosREP.Inserir(contato);
                    }

                    if (contato.ID !=null && !String.IsNullOrEmpty(contato.Descricao))
                    {
                        _contatosREP.Atualizar(contato);

                    }
                }

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
    }
}
