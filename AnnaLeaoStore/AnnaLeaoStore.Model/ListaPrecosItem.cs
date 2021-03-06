﻿using System;

namespace AnnaLeaoStore.Model
{
    public class ListaPrecosItem
    {
		public int? ID { get; set; }
        public Decimal? Preco_Compra { get; set; }
        public Decimal? Preco_Venda { get; set; }
        public Decimal? Lucro_Estimado { get; set; }
        public Decimal? Desconto_Max_Permitido { get; set; }
        public Decimal? Percentual_Estimado { get; set; }

        public virtual Produtos Produtos { get; set; }
		public virtual ListaPrecos ListaPrecos { get; set; }
    }
}
