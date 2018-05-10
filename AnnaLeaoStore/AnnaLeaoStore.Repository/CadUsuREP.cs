using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Web.Helpers;
using System.Data;

namespace AnnaLeaoStore.Repository
{
    public class CadUsuREP
    {
        private ADO _ado = new ADO();

        private String _strSql;

        public CadUsuMOD Acesso(CadUsuMOD dados)
        {
            String senha = Crypto.SHA256(dados.Senha);

            _strSql = $@"SELECT DESCRICAO FROM CADUSU USU JOIN CADNIVEL NIV ON USU.NIVEL = NIV.ID WHERE USUARIO = '{dados.Usuario}' AND SENHA = '{senha}'";

            DataTable registro = _ado.RetornarTabela(_strSql);

            CadUsuMOD usuario = new CadUsuMOD
            {
                Nivel = registro.Rows[0]["DESCRICAO"].ToString()
            };

            return usuario;
        }

    }
}
