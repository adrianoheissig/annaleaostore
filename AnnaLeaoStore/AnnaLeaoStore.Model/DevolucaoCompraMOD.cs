using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class DevolucaoCompraMOD
    {
        public Int32 ID { get; set; }
        public Int32 IDPedidoCompra { get; set; }
        public string Motivo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
