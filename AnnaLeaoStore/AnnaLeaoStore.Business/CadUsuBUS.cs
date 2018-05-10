using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Business
{
    public class CadUsuBUS
    {
        private CadUsuREP _cadUsuRep = new CadUsuREP();

        public bool Acesso(CadUsuMOD dados)
        {
            try
            {
                CadUsuMOD usuario = _cadUsuRep.Acesso(dados);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
