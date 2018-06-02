using AnnaLeaoStore.Business.Interfaces;
using AnnaLeaoStore.Model;
using AnnaLeaoStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Business
{
    public class PessoasBUS : IServiceBase<Pessoas>
    {
        private PessoasREP _pessoasRep = new PessoasREP();

        private Pessoas _pessoaMOD = new Pessoas();

        public void Delete(Pessoas pessoa)
        {
            try
            {
                _pessoasRep.Delete(pessoa);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Pessoas> GetAll()
        {
            return null;
        }

        public List<Pessoas> GetAll(int tipo)
        {
            return _pessoasRep.GetAll(tipo);
        }

        public Pessoas GetByID(int id)
        {
            return _pessoasRep.GetByID(id);
        }

        public Pessoas Insert(Pessoas pessoa)
        {
            try
            {
                _pessoaMOD = ValidaPessoa(pessoa);

                return _pessoasRep.Insert(_pessoaMOD);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Update(Pessoas pessoa)
        {
            try
            {
                _pessoaMOD = ValidaPessoa(pessoa);

                _pessoasRep.Update(_pessoaMOD);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Pessoas ValidaPessoa(Pessoas pessoa)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoa.Nome))
                {
                    throw new Exception("Nome não pode ser Em Branco!");
                }

                return pessoa;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        void IServiceBase<Pessoas>.Insert(Pessoas entity)
        {
           
        }
    }
}
