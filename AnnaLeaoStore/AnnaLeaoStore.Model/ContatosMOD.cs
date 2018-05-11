using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class ContatosMOD
    {
        public Int32 ID { get; set; }
        public Int32 IDTipoRedeSocial { get; set; }
        public string TipoCadastro { get; set; }
        public string Descricao { get; set; }
        public string IDPessoa { get; set; }
    }
}
