using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class ProdutosMOD
    {
        public int? ID { get; set; }
        public string ReferId { get; set; }
        public string Descricao { get; set; }
        public string DescricaoSituacao { get; set; }
        public string Cor { get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public int? Situacao { get; set; }
        public string Observacao { get; set; }
        public string LinkProduto { get; set; }
        public bool Ativo { get; set; }

        public decimal? QtdeEstoque { get; set; }

        public PessoasMOD Pessoas { get; set; }
        public GradeProdutosMOD Grade { get; set; }



    }
}
