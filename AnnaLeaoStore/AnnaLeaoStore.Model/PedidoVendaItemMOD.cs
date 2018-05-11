using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class PedidoVendaItemMOD
    {
        public Int32 ID { get; set; }
        public Int32 IDPedido { get; set; }
        public Int32 Item { get; set; }
        public Int32 IDProdutos { get; set; }
        public Decimal PrecoTabela { get; set; }
        public Decimal PrecoVenda { get; set; }
        public Decimal Desconto { get; set; }
        public Decimal Acrescimo { get; set; }
        public Decimal Quantidade { get; set; }
        public string Tamanho { get; set; }
    }
}
