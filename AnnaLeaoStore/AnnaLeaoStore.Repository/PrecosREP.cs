using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository.Extensions;

namespace AnnaLeaoStore.Repository
{
    public class PrecosREP
    {
		private DBContext db = new DBContext();

		public List<ListaPrecos> GetAll()
        {
            try
            {
                return db.ListaPrecosMOD.ToList();
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
                return db.ListaPrecosMOD.Find(id);
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
             
                ListaPrecos preco = new ListaPrecos();
                preco = GetById(id);
                db.ListaPrecosMOD.Remove(preco);
                
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public ListaPrecos Inserir(ListaPrecos precos)
        {
            try
            {
                db.ListaPrecosMOD.Add(precos);
                db.SaveChanges();

                return precos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public void Atualizar(ListaPrecos preco)
        {
            try
            {
                ListaPrecos precoOri = new ListaPrecos();
                precoOri = GetById((int)preco.ID);

                precoOri.Descricao = preco.Descricao;
                precoOri.Validade = preco.Validade;
                
                db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
