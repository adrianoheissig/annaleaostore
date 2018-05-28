using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using AnnaLeaoStore.Repository.Extensions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Repository
{
    public class TipoContatoREP
    {
		private ADO _ado = new ADO();
        public List<TipoContato> GetAll()
        {
            string storedProcedure = "LISTARTIPODECONTATO";
            List<TipoContato> tiposContato = new List<TipoContato>();

			DataTable registros = _ado.RetornarTabela(storedProcedure, CommandType.StoredProcedure);

            foreach (DataRow item in registros.Rows)
            {
				tiposContato.Add(new TipoContato
                {
					ID = item.GetValue<int>("ID"),
					Descricao = item.GetText("DESCRICAO")
                });
            }

			return tiposContato;

        }
    }
}
