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
        public Int32 ID { get; set; }
        public string Referid { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public Int32 IDGrade { get; set; }
        public Int32 IDFornecedor { get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public Int32 Situacao { get; set; }
        public string Observacao { get; set; }
        public string Tam1 { get; set; }
        public string Tam2 { get; set; }
        public string Tam3 { get; set; }
        public string Tam4 { get; set; }
        public string Tam5 { get; set; }
        public string Tam6 { get; set; }
        public string Tam7 { get; set; }
        public string Tam8 { get; set; }
        public string Tam9 { get; set; }
        public string Tam10 { get; set; }
        public string LinkProduto { get; set; }



    }
}
