using System.Collections.Generic;

namespace AnnaLeaoStore.Model
{
    public class Contatos
    {

        public int? ID { get; set; }
        public string Descricao { get; set; }

        public virtual Pessoas Pessoas { get; set; }

        public virtual TipoDeContato TipoDeContato { get; set; }
    }
}
