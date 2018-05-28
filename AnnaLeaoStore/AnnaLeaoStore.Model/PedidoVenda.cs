using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class PedidoVenda
    {
        public Int32 ID { get; set; }
        public Int32 IDTipoPagamento { get; set; }
        public DateTime DataPedido { get; set; }
        public Int32 IDListaPreco { get; set; }
        public Int32 IDPessoa { get; set; }
        public Int32 IDTipoVenda { get; set; }
    }
}
