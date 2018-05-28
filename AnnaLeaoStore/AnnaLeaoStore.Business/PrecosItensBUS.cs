using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;

namespace AnnaLeaoStore.Business
{
    public class PrecosItensBUS
    {
		private PrecosItemREP _precosItemREP = new PrecosItemREP();
		private ListaPrecosItem _precosItemMOD = new ListaPrecosItem();

		public List<ListaPrecosItem> GetAll(int idPedido)
        {
            return _precosItemREP.GetAll(idPedido);
        }
        
		public void Deletar(int id){
			try
			{
                _precosItemREP.Deletar(id);

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Insert(ListaPrecosItem precosItem)
        {
            try
            {
                _precosItemMOD = ValidaPreco(precosItem);
                _precosItemREP.Inserir(_precosItemMOD);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

		public ListaPrecosItem ValidaPreco(ListaPrecosItem precosItem)
        {
            try
            {               
                return precosItem;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
