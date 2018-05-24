using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class PessoasMOD
    {
        public int? ID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Pais{ get; set; }
        public int? Situacao { get; set; }
        public bool Ativo { get; set; }
        public string DescricaoSituacao { get; set; }
        public string Observacao { get; set; }
        public int TipoPessoa { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string EnderecoEntrega { get; set; }
        public string BairroEntrega { get; set; }
        public string CidadeEntrega { get; set; }
        public string EstadoEntrega { get; set; }
        public string CepEntrega { get; set; }
        public string PaisEntrega { get; set; }
        public string NomeDestinatario { get; set; }

		public virtual ICollection<ContatosMOD> Contatos { get; set; }

    }
}
