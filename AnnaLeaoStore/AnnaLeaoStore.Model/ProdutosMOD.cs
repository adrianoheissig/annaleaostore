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
        public string Referid { get; set; }
        public string Descricao { get; set; }
        public string DescricaoSituacao { get; set; }
        public string Cor { get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public int? Situacao { get; set; }
        public string Observacao { get; set; }
        public string LinkProduto { get; set; }

        public virtual PessoasMOD Pessoas { get; set; }
        public virtual GradeProdutosMOD Grade { get; set; }



    }
}
