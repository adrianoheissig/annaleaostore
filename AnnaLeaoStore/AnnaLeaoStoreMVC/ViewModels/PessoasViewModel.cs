using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;

namespace AnnaLeaoStoreMVC.ViewModels
{
    public class PessoasViewModel
    {
        public int? ID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public Decimal? Situacao { get; set; }
        public string Observacao { get; set; }
        public Decimal TipoPessoa { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string EnderecoEntrega { get; set; }
        public string BairroEntrega { get; set; }
        public string CidadeEntrega { get; set; }
        public string EstadoEntrega { get; set; }
        public string CepEntrega { get; set; }
        public string PaisEntrega { get; set; }
        public string NomeDestinatario { get; set; }

        public virtual ICollection<Contatos> Contatos { get; set; }

        public string DescricaoSituacao { get; set; }
        public bool Ativo { get; set; }
    }
}