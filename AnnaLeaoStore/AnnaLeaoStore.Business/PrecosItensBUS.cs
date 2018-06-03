using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;
using System;
using System.Collections.Generic;

namespace AnnaLeaoStore.Business
{
    public class PrecosItensBUS
    {
        private PrecosItemREP _precosItemREP = new PrecosItemREP();

        public List<ListaPrecosItem> GetAll(int idPedido)
        {
            return _precosItemREP.GetAll(idPedido);
        }

        public void Deletar(int id)
        {
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
                ValidaPreco(precosItem);
                _precosItemREP.Inserir(precosItem);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ValidaPreco(ListaPrecosItem precosItem)
        {
            try
            {
                if (_precosItemREP.VerificaItemCadastrado(precosItem))
                {
                    throw new Exception("Preço para o Produto já cadastrado!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
