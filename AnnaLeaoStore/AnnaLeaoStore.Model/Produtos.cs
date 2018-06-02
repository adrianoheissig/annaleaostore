using System;
using System.Collections.Generic;

namespace AnnaLeaoStore.Model
{
    public class Produtos
    {
        public int? ID { get; set; }
        public string ReferId { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public Decimal? Situacao { get; set; }
        public string Observacao { get; set; }
        public string LinkProduto { get; set; }
        
        public virtual Pessoas Pessoas { get; set; }
        public virtual Grades Grades { get; set; }
             

    }
}
