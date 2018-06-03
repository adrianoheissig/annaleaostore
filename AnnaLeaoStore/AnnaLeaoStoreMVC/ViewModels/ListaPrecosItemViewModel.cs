using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnaLeaoStoreMVC.ViewModels
{
    public class ListaPrecosItemViewModel
    {
        public int? ID { get; set; }
        public Decimal? Preco_Compra { get; set; }
        public Decimal? Preco_Venda { get; set; }
        public Decimal? Lucro_Estimado { get; set; }
        public Decimal? Desconto_Max_Permitido { get; set; }
        public Decimal? Percentual_Estimado { get; set; }

        public int? Produtos_ID { get; set; }
        public int? ListaPrecos_ID { get; set; }
    }
}