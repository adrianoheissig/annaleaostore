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
    }
}
