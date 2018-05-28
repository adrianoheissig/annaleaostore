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
		public int? ID { get; set; }
        public Decimal? PrecoCompra { get; set; }
        public Decimal? PrecoVenda { get; set; }
        public Decimal? LucroEstimado { get; set; }
        public Decimal? DescontoMaxPermitido { get; set; }

		public ProdutosMOD Produtos { get; set; }
		public ListaPrecosMOD ListaPrecos { get; set; }
    }
}
