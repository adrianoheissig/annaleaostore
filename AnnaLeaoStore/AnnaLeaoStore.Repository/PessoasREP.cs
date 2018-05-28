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
    public class PessoasREP : IRepositoryBase<Pessoas>
    {
        private ADO _ado = new ADO();

        private String _strSql;

        public void Delete(Pessoas pessoa)
        {
            try
            {

                string storedProcedure = "DELETAR_PESSOA";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pessoa.ID);

                _ado.ExecutarSql(_ado.ObterCommand(cmd));


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Pessoas> GetAll()
        {
            return null;
        }
        public List<Pessoas> GetAll(int tipo)
        {
            _strSql = $@"SELECT ID,NOME,ENDERECO,BAIRRO
                              ,CIDADE,ESTADO,CEP,PAIS
                              ,SITUACAO
							  ,CASE WHEN SITUACAO = 0 THEN 'INATIVO' ELSE 'ATIVO' END AS DESC_SITUACAO
							  ,CASE WHEN SITUACAO = 0 THEN 'False' ELSE 'True' END AS ATIVO
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

            return RetornLista(_strSql);
        }

        public Pessoas GetByID(int id)
        {
            Pessoas pessoa = new Pessoas();

            _strSql = $@"SELECT ID,NOME,ENDERECO,BAIRRO
                              ,CIDADE,ESTADO,CEP,PAIS
                              ,SITUACAO
							  ,CASE WHEN SITUACAO = 0 THEN 'INATIVO' ELSE 'ATIVO' END AS DESC_SITUACAO
							  ,CASE WHEN SITUACAO = 0 THEN 'False' ELSE 'True' END AS ATIVO
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

            List<Pessoas> pessoas = new List<Pessoas>();

            pessoas = RetornLista(_strSql);

            pessoa = pessoas.FirstOrDefault();

            return pessoa;

        }


        public Pessoas Insert(Pessoas pessoa)
        {
            try
            {
                string storedProcedure = "INSERIR_PESSOA";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter outPutVal = new SqlParameter("@NOVOID", SqlDbType.Int);
                outPutVal.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outPutVal);
                cmd.Parameters.AddWithValue("@NOME", pessoa.Nome);
                cmd.Parameters.AddWithValue("@ENDERECO", pessoa.Endereco, null);
                cmd.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro, null);
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

                if (outPutVal.Value != DBNull.Value) pessoa.ID = Convert.ToInt32(outPutVal.Value);

                return pessoa;


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public void Update(Pessoas pessoa)
        {
            try
            {
                string storedProcedure = "ATUALIZAR_PESSOA";
                var cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pessoa.ID);
                cmd.Parameters.AddWithValue("@NOME", pessoa.Nome);
                cmd.Parameters.AddWithValue("@ENDERECO", pessoa.Endereco, null);
                cmd.Parameters.AddWithValue("@BAIRRO", pessoa.Bairro, null);
                cmd.Parameters.AddWithValue("@CIDADE", pessoa.Cidade, null);
                cmd.Parameters.AddWithValue("@ESTADO", pessoa.Estado, null);
                cmd.Parameters.AddWithValue("@CEP", pessoa.Cep, null);
                cmd.Parameters.AddWithValue("@PAIS", pessoa.Pais, null);
                cmd.Parameters.AddWithValue("@SITUACAO", pessoa.Situacao);
                cmd.Parameters.AddWithValue("@OBSERVACAO", pessoa.Observacao, null);
                cmd.Parameters.AddWithValue("@TIPOPESSOA", pessoa.TipoPessoa);
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

        void IRepositoryBase<Pessoas>.Insert(Pessoas entity)
        {
            
        }

        private List<Pessoas> RetornLista(string select)
        {
            List<Pessoas> pessoas = new List<Pessoas>();

			DataTable registros = _ado.RetornarTabela(select, CommandType.Text);

            foreach (DataRow item in registros.Rows)
            {

                pessoas.Add(new Pessoas
                {
                    ID = item.GetValue<int>("ID"),
                    Nome = item.GetText("NOME"),
                    Endereco = item.GetText("ENDERECO"),
                    Bairro = item.GetText("BAIRRO"),
                    Cidade = item.GetText("CIDADE"),
                    Estado = item.GetText("ESTADO"),
                    Cep = item.GetText("CEP"),
                    Pais = item.GetText("PAIS"),
					Situacao = item.GetValue<int>("SITUACAO"),
					TipoPessoa = Convert.ToInt32(item["TIPOPESSOA"]),
                    DescricaoSituacao = item.GetText("DESC_SITUACAO"),
                    Ativo = item.GetBool("Ativo"),
                    Observacao = item.GetText("OBSERVACAO"),
                    DataCadastro = item.GetValue<DateTime>("DATACADASTRO"),
                    DataNascimento = item.GetValue<DateTime>("DATANASCIMENTO"),
                    EnderecoEntrega = item.GetText("ENDERECOENTREGA"),
                    BairroEntrega = item.GetText("BAIRROENTREGA"),
                    CidadeEntrega = item.GetText("CIDADEENTREGA"),
                    EstadoEntrega = item.GetText("ESTADOENTREGA"),
                    CepEntrega = item.GetText("CEPENTREGA"),
                    PaisEntrega = item.GetText("PAISENTREGA"),
                    NomeDestinatario = item.GetText("NOMEDESTINATARIO")
                });
            }

            return pessoas;
        }

    }
}
