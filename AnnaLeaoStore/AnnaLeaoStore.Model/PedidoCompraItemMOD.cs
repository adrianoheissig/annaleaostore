using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class PedidoCompraItemMOD
    {
        public Int32 ID { get; set; }
        public Int32 IDPedidoCompra { get; set; }
        public Int32 Item { get; set; }
        public Int32 IDProduto { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal PrecoCompra { get; set; }
    }
}
