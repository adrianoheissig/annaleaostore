using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AnnaLeaoStore.Repository.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Repository
{
    public class PessoasREP : IRepositoryBase<PessoasMOD>
    {
        private ADO _ado = new ADO();

        private String _strSql;

        public void Delete(PessoasMOD pessoa)
        {
            try
            {
                _strSql = $@"DELETE FROM PESSOAS WHERE ID = {pessoa.ID}";

                _ado.ExecutarComando(_strSql);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<PessoasMOD> GetAll()
        {
            return null;
        }
        public List<PessoasMOD> GetAll(int tipo)
        {
            List<PessoasMOD> pessoas = new List<PessoasMOD>();

            _strSql = $@"SELECT ID
                              ,NOME
                              ,ENDERECO
                              ,BAIRRO
                              ,CIDADE
                              ,ESTADO
                              ,CEP
                              ,PAIS
                              ,SITUACAO
                              ,OBSERVACAO
                              ,TIPOPESSOA
                              ,DATACADASTRO
                              ,DATANASCIMENTO
                              ,ENDERECOENTREGA
                              ,BAIRROENTREGA
                              ,CIDADEENTREGA
                              ,ESTADOENTREGA
                              ,CEPENTREGA
                              ,PAISENTREGA
                              ,NOMEDESTINATARIO FROM PESSOAS WHERE TIPOPESSOA = {tipo}";

            DataTable registros = _ado.RetornarTabela(_strSql);

            foreach (DataRow item in registros.Rows)
            {
                pessoas.Add(new PessoasMOD
                {
                    ID = Convert.ToInt32(item["ID"]),
                    Nome = item["NOME"] == DBNull.Value ? String.Empty : item["NOME"].ToString(),
                    Endereco = item["ENDERECO"] == DBNull.Value ? String.Empty : item["ENDERECO"].ToString(),
                    Bairro = item["BAIRRO"] == DBNull.Value ? String.Empty : item["BAIRRO"].ToString(),
                    Cidade = item["CIDADE"] == DBNull.Value ? String.Empty : item["CIDADE"].ToString(),
                    Estado = item["ESTADO"] == DBNull.Value ? String.Empty : item["ESTADO"].ToString(),
                    Cep = item["CEP"] == DBNull.Value ? String.Empty : item["CEP"].ToString(),
                    Pais = item["PAIS"] == DBNull.Value ? String.Empty : item["PAIS"].ToString(),
                    Situacao = item["SITUACAO"] == DBNull.Value ? 0 : Convert.ToInt32(item["SITUACAO"]),
                    DescricaoSituacao = item["SITUACAO"] == DBNull.Value ? "Inativo" : (Convert.ToInt32(item["SITUACAO"]) == 0 ? "Inativo" : "Ativo"),
                    Ativo = item["SITUACAO"] == DBNull.Value ? false : (Convert.ToInt32(item["SITUACAO"]) == 0 ? false : true),
                    Observacao = item["OBSERVACAO"] == DBNull.Value ? String.Empty : item["OBSERVACAO"].ToString(),
                    /* DataCadastro =  Convert.ToDateTime(item["DATACADASTRO"]),
                     DataNascimento = Convert.ToDateTime(item["DATANASCIMENTO"]),
                     EnderecoEntrega = item["ENDERECOENTREGA"].ToString(),
                     BairroEntrega = item["BAIRROENTREGA"].ToString(),
                     CidadeEntrega = item["CIDADEENTREGA"].ToString(),
                     EstadoEntrega = item["ESTADOENTREGA"].ToString(),
                     CepEntrega = item["CEPENTREGA"].ToString(),
                     PaisEntrega = item["PAISENTREGA"].ToString(),
                     NomeDestinatario = item["NOMEDESTINATARIO"].ToString() */
                });
            }

            return pessoas;
        }

        public PessoasMOD GetByID(int id)
        {
            PessoasMOD pessoa = new PessoasMOD();

            _strSql = $@"SELECT ID
                              ,NOME
                              ,ENDERECO
                              ,BAIRRO
                              ,CIDADE
                              ,ESTADO
                              ,CEP
                              ,PAIS
                              ,SITUACAO
                              ,OBSERVACAO
                              ,TIPOPESSOA
                              ,DATACADASTRO
                              ,DATANASCIMENTO
                              ,ENDERECOENTREGA
                              ,BAIRROENTREGA
                              ,CIDADEENTREGA
                              ,ESTADOENTREGA
                              ,CEPENTREGA
                              ,PAISENTREGA
                              ,NOMEDESTINATARIO FROM PESSOAS WHERE ID = {id}";
            DataTable registro = _ado.RetornarTabela(_strSql);

            pessoa.ID = Convert.ToInt32(registro.Rows[0]["ID"]);
            pessoa.Nome = registro.Rows[0]["NOME"] == DBNull.Value ? String.Empty : registro.Rows[0]["NOME"].ToString();
            pessoa.Endereco = registro.Rows[0]["ENDERECO"] == DBNull.Value ? String.Empty : registro.Rows[0]["ENDERECO"].ToString();
            pessoa.Bairro = registro.Rows[0]["BAIRRO"] == DBNull.Value ? String.Empty : registro.Rows[0]["BAIRRO"].ToString();
            pessoa.Cidade = registro.Rows[0]["CIDADE"] == DBNull.Value ? String.Empty : registro.Rows[0]["CIDADE"].ToString();
            pessoa.Estado = registro.Rows[0]["ESTADO"] == DBNull.Value ? String.Empty : registro.Rows[0]["ESTADO"].ToString();
            pessoa.Cep = registro.Rows[0]["CEP"] == DBNull.Value ? String.Empty : registro.Rows[0]["CEP"].ToString();
            pessoa.Pais = registro.Rows[0]["PAIS"] == DBNull.Value ? String.Empty : registro.Rows[0]["PAIS"].ToString();
            pessoa.Situacao = registro.Rows[0]["SITUACAO"] == DBNull.Value ? 0 : Convert.ToInt32(registro.Rows[0]["SITUACAO"]);
            pessoa.DescricaoSituacao = registro.Rows[0]["SITUACAO"] == DBNull.Value ? "Inativo" : (Convert.ToInt32(registro.Rows[0]["SITUACAO"]) == 0 ? "Inativo" : "Ativo");
            pessoa.Ativo = registro.Rows[0]["SITUACAO"] == DBNull.Value ? false : (Convert.ToInt32(registro.Rows[0]["SITUACAO"]) == 0 ? false : true);
            pessoa.Observacao = registro.Rows[0]["OBSERVACAO"] == DBNull.Value ? String.Empty : registro.Rows[0]["OBSERVACAO"].ToString();
            /* DataCadastro =  Convert.ToDateTime(item["DATACADASTRO"]);
             DataNascimento = Convert.ToDateTime(item["DATANASCIMENTO"]);
             EnderecoEntrega = item["ENDERECOENTREGA"].ToString();
             BairroEntrega = item["BAIRROENTREGA"].ToString();
             CidadeEntrega = item["CIDADEENTREGA"].ToString();
             EstadoEntrega = item["ESTADOENTREGA"].ToString();
             CepEntrega = item["CEPENTREGA"].ToString();
             PaisEntrega = item["PAISENTREGA"].ToString();
             NomeDestinatario = item["NOMEDESTINATARIO"].ToString(); */

            return pessoa;

        }

        public void Insert(PessoasMOD pessoa)
        {
            try
            {
                string storedProcedure = "INSERIR_PESSOA";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NOME", pessoa.Nome);
                cmd.Parameters.AddWithValue("@ENDERECO", pessoa.Endereco, null);
                cmd.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro,null);
                cmd.Parameters.AddWithValue("@CIDADE", pessoa.Cidade, null);
                cmd.Parameters.AddWithValue("@ESTADO", pessoa.Estado, null);
                cmd.Parameters.AddWithValue("@CEP", pessoa.Cep, null);
                cmd.Parameters.AddWithValue("@PAIS", pessoa.Pais, null);
                cmd.Parameters.AddWithValue("@SITUACAO", pessoa.Situacao);
                cmd.Parameters.AddWithValue("@OBSERVACAO", pessoa.Observacao, null);
                cmd.Parameters.AddWithValue("@TIPOPESSOA", pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("@DATACADASTRO", pessoa.DataCadastro, null);
                cmd.Parameters.AddWithValue("@DATANASCIMENTO", pessoa.DataNascimento, null);
                cmd.Parameters.AddWithValue("@ENDERECOENTREGA", pessoa.EnderecoEntrega, null);
                cmd.Parameters.AddWithValue("@BAIRROENTREGA", pessoa.BairroEntrega, null);
                cmd.Parameters.AddWithValue("@CIDADEENTREGA", pessoa.CidadeEntrega, null);
                cmd.Parameters.AddWithValue("@ESTADOENTREGA", pessoa.EstadoEntrega, null);
                cmd.Parameters.AddWithValue("@CEPENTREGA", pessoa.CepEntrega, null);
                cmd.Parameters.AddWithValue("@PAISENTREGA", pessoa.PaisEntrega, null);
                cmd.Parameters.AddWithValue("@NOMEDESTINATARIO", pessoa.NomeDestinatario, null);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public void Update(PessoasMOD pessoa)
        {
            try
            {
                _strSql = $@"UPDATE PESSOAS
   SET NOME = {pessoa.Nome}
      ,ENDERECO = {pessoa.Endereco}
      ,BAIRRO = {pessoa.Bairro}
      ,CIDADE = {pessoa.Cidade}
      ,ESTADO = {pessoa.Estado}
      ,CEP = {pessoa.Cep}
      ,PAIS = {pessoa.Pais}
      ,SITUACAO = {pessoa.Situacao}
      ,OBSERVACAO = {pessoa.Observacao}
      ,TIPOPESSOA = {pessoa.TipoPessoa}
      ,DATACADASTRO = {pessoa.DataCadastro}
      ,DATANASCIMENTO = {pessoa.DataNascimento}
      ,ENDERECOENTREGA = {pessoa.EnderecoEntrega}
      ,BAIRROENTREGA = {pessoa.BairroEntrega}
      ,CIDADEENTREGA = {pessoa.CidadeEntrega}
      ,ESTADOENTREGA = {pessoa.EstadoEntrega}
      ,CEPENTREGA = {pessoa.CepEntrega}
      ,PAISENTREGA = {pessoa.PaisEntrega}
      ,NOMEDESTINATARIO = {pessoa.NomeDestinatario}
 WHERE ID = {pessoa.ID}";

                _ado.ExecutarComando(_strSql);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

    }
}
