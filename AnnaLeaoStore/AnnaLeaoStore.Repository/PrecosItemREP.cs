using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class PrecosItemREP
    {
		private DBContext db = new DBContext();

		public List<ListaPrecosItem> GetAll(int idPedido)
        {
            try
            {
                return db.ListaPrecosItemMOD.Where(_x => (int)_x.ListaPrecos.ID == idPedido).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                ListaPrecosItem precoItem = new ListaPrecosItem();
                precoItem = db.ListaPrecosItemMOD.Find(id);
                db.ListaPrecosItemMOD.Remove(precoItem);
                
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public void Inserir(ListaPrecosItem precoItem)
        {
            try
            {
                precoItem.ListaPrecos = db.ListaPrecosMOD.Find(precoItem.ListaPrecos.ID);
                precoItem.Produtos = db.ProdutosMOD.Find(precoItem.Produtos.ID);
                db.ListaPrecosItemMOD.Add(precoItem);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool VerificaItemCadastrado(ListaPrecosItem precoItem)
        {
            try
            {
                return db.ListaPrecosItemMOD.Where(s => s.ListaPrecos.ID == precoItem.ListaPrecos.ID && s.Produtos.ID == precoItem.Produtos.ID).Count() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
