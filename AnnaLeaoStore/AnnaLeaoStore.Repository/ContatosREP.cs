using System;
using System.Collections.Generic;
using System.Data;
using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository.Extensions;

namespace AnnaLeaoStore.Repository
{
    public class ContatosREP
    {
		private ADO _ado = new ADO();

		private string _strSQL;
        
		public List<ContatosMOD> GetID(int id)
        {
            try
			{
				_strSQL = "LISTARCONTATOSPORID";

				List<ContatosMOD> contatos = new List<ContatosMOD>();

				DataTable registros = _ado.RetornarTabela(_strSQL, CommandType.StoredProcedure,"@IDPESSOA",id);

				foreach (DataRow item in registros.Rows)
				{
					contatos.Add(new ContatosMOD
					{
                        ID = item.GetValue<int>("ID"),
						IDTipoRedeSocial = item.GetValue<int>("IDTIPOREDESOCIAL"),
						TipoContato = item.GetText("TIPODECONTATO"),
						Descricao = item.GetText("DESCRICAO")
					});
				}
				return contatos;
			} catch (Exception ex) {
				throw new Exception(ex.Message);
            }

        }
    }
}
