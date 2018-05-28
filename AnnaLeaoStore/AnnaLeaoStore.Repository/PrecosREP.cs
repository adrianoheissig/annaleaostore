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
        private ADO _ado = new ADO();

        private string _strSQL;

		private DBContext db = new DBContext();

		public List<ListaPrecosMOD> GetAll()
        {
            try
            {
				/*_strSQL = "LISTARPRECOS";

                List<ListaPrecosMOD> precos = new List<ListaPrecosMOD>();

                DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure);

                foreach (DataRow item in registros.Rows)
                {
                    precos.Add(new ListaPrecosMOD
                    {
                        ID = item.GetValue<int>("ID"),
                        Descricao = item.GetText("DESCRICAO"),
						Validade = item.GetValue<DateTime>("VALIDADE"),
						DataValidadeFmt = item.GetValue<DateTime>("VALIDADE").ToString()
                    });
                }
                return precos;
                */

                return db.ListaPrecosMOD.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ListaPrecosMOD GetById(int id)
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
             
                ListaPrecosMOD preco = new ListaPrecosMOD();
                preco = GetById(id);
                db.ListaPrecosMOD.Remove(preco);

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

		public ListaPrecosMOD Inserir(ListaPrecosMOD precos)
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

		public void Atualizar(ListaPrecosMOD preco)
        {
            try
            {
                ListaPrecosMOD precoOri = new ListaPrecosMOD();
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
