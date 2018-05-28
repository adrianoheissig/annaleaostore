using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class PedidoCompra
    {
        public Int32 ID { get; set; }
        public Int32 IDTipoPagamento { get; set; }
        public DateTime DataCompra { get; set; }
        public Int32 IDPessoa { get; set; }
    }
}
