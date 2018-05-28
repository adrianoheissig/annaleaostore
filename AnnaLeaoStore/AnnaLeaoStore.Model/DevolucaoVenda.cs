using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class DevolucaoVenda
    {
        public Int32 ID { get; set; }
        public Int32 IDPedidoItem { get; set; }
        public string Motivo { get; set; }
        public Decimal Quantidade { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
