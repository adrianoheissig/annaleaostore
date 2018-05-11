using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class ListaPrecosItemMOD
    {
        public Int32 ID { get; set; }
        public Int32 IDListaPrecos { get; set; }
        public Int32 IDProdutos { get; set; }
        public Decimal PrecoCompra { get; set; }
        public Decimal PrecoVenda { get; set; }
        public Decimal LucroEstimado { get; set; }
        public Decimal DescontoMaxPermitido { get; set; }
    }
}
