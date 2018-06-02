using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;

namespace AnnaLeaoStoreMVC.ViewModels
{
    public class ProdutosViewModel
    {

        public ProdutosViewModel()
        {
            NomeGrade = new List<string>();
            QtdeTam = new List<decimal>();
        }


        public int? ID { get; set; }
        public string ReferId { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public DateTime? DataUltimaCompra { get; set; }
        public int? Situacao { get; set; }
        public string Observacao { get; set; }
        public string LinkProduto { get; set; }

        public Pessoas Pessoas { get; set; }
        public Grades Grades { get; set; }

        public decimal QtdeEstoque { get; set; }
        public string DescSituacao { get; set; }
        public bool Ativo { get; set; }

        public string NomeFornecedor { get; set; }

        public Estoque Estoque { get; set; }



        public List<string> NomeGrade { get; set; }
        public List<Decimal> QtdeTam { get; set; }


    }
}