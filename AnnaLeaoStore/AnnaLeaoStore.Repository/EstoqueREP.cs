using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class EstoqueREP
    {
        private DBContext db = new DBContext();

        public Decimal TotalEstoquePorProduto(int idProduto)
        {

            try
            {
                var totalEstoque =  db.EstoquesMOD.Where(s => (int)s.Produtos_ID == idProduto).Sum(s => (decimal)s.Tam1 + (decimal)s.Tam2 + (decimal)s.Tam3 + (decimal)s.Tam4 + (decimal)s.Tam5 + (decimal)s.Tam6 + (decimal)s.Tam7 + (decimal)s.Tam8 + (decimal)s.Tam9 + (decimal)s.Tam10);

                return totalEstoque;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       public Estoque EstoqueDoProduto(int idProduto)
        {
            var estoque = db.EstoquesMOD.Where(s => (int)s.Produtos_ID == idProduto).FirstOrDefault();

            return estoque;
        }

    }
}
