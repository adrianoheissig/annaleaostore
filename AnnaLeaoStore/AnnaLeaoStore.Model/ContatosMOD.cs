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
        public int? ID { get; set; }
        public int? IDTipoRedeSocial { get; set; }
        public string TipoContato { get; set; }
        public string Descricao { get; set; }
        public int IDPessoa { get; set; }

		public virtual PessoasMOD Pessoas{get;set;}
    }
}
