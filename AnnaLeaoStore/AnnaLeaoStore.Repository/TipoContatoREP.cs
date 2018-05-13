using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Repository
{
    public class TipoContatoREP
    {
        public List<TipoContatoMOD> GetAll()
        {
            string storedProcedure = "LISTARTIPODECONTATO";
            var cmd = new SqlCommand(storedProcedure);
            cmd.CommandType = CommandType.StoredProcedure;

            List<TipoContatoMOD> pessoas = new List<TipoContatoMOD>();

            DataTable registros = _ado.RetornarTabela(select);

            foreach (DataRow item in registros.Rows)
            {
                pessoas.Add(new PessoasMOD
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
