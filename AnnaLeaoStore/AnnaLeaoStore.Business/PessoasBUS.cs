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
    public class PessoasBUS : IServiceBase<PessoasMOD>
    {
        private PessoasREP _pessoasRep = new PessoasREP();

        public void Delete(PessoasMOD pessoa)
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

        public List<PessoasMOD> GetAll()
        {
            return null;
        }

        public List<PessoasMOD> GetAll(int tipo)
        {
            return _pessoasRep.GetAll(tipo);
        }

        public PessoasMOD GetByID(int id)
        {
            return _pessoasRep.GetByID(id);
        }

        public void Insert(PessoasMOD pessoa)
        {
            try
            {
                ValidaPessoa(pessoa);

                _pessoasRep.Insert(pessoa);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Update(PessoasMOD pessoa)
        {
            try
            {
                ValidaPessoa(pessoa);

                _pessoasRep.Update(pessoa);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void ValidaPessoa(PessoasMOD pessoa)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoa.Nome))
                {
                    throw new Exception("Nome não pode ser Em Branco!");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
