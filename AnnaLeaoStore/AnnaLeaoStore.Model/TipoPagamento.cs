using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class TipoPagamento
    {
        public Int32 ID { get; set; }
        public string Descricao { get; set; }
        public Int32 Prazo { get; set; }
        public Decimal CustoFinanceiro { get; set; }
        public Decimal Taxa { get; set; }
    }
}
