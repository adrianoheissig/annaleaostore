using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
    public class TipoContatoBUS
    {
		private TipoContatoREP _tipoContatoREP = new TipoContatoREP();

        public List<TipoContato> GetAll()
        {
			return _tipoContatoREP.GetAll();
        }
    }
}
