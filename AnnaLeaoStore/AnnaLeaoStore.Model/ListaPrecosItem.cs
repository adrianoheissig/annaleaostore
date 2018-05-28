using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class ListaPrecosItem
    {
		public int? ID { get; set; }
        public Decimal? Preco_Compra { get; set; }
        public Decimal? Preco_Venda { get; set; }
        public Decimal? Lucro_Estimado { get; set; }
        public Decimal? Desconto_Max_Permitido { get; set; }

        public Produtos Produtos { get; set; }
		public ListaPrecos ListaPrecos { get; set; }
    }
}
