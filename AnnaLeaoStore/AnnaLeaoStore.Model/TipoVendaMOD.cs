using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class TipoVendaMOD
    {
        public Int32 ID { get; set; }
        public string Descricao { get; set; }
        public Int32 GeraVenda { get; set; }
    }
}
