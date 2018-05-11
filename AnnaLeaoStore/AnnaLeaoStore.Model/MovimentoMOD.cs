using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class MovimentoMOD
    {
        public Int32 ID { get; set; }
        public Int32 IDProdutos { get; set; }
        public Decimal Quantidade { get; set; }
        public string Operacao { get; set; }
    }
}
