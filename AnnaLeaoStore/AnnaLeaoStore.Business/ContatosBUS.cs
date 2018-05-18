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

		public void Inserir(ContatosMOD contatos){
			try
			{
				if (String.IsNullOrEmpty(contatos.Descricao))
				{
					throw new Exception("Descrição não pode ser em branco");
				}
				_contatosREP.Inserir(contatos);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
    }
}
