using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
    public class TipoDeContatoBUS
    {
		private TipoDeContatoREP _TipoDeContatoREP = new TipoDeContatoREP();

        public List<TipoDeContato> GetAll()
        {
			return _TipoDeContatoREP.GetAll();
        }
    }
}
