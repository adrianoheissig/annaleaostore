using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System.Collections.Generic;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class TipoDeContatoREP
    {
        private DBContext db = new DBContext();
        public List<TipoDeContato> GetAll()
        {
            return db.TipoDeContatoMOD.ToList();
        }
    }
}
