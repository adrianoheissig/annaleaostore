using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;
using System;

namespace AnnaLeaoStore.Business
{
    public class EstoqueBUS
    {
        private EstoqueREP _estoqueRep = new EstoqueREP();

        public Decimal TotalEstoquePorProduto(int idProduto)
        {
            try
            {
                return _estoqueRep.TotalEstoquePorProduto(idProduto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Estoque EstoqueDoProduto (int idProduto)
        {
            try
            {
                return _estoqueRep.EstoqueDoProduto(idProduto);
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }
    }


}
