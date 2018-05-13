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

        private PessoasMOD _pessoaMOD = new PessoasMOD();

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

        public PessoasMOD Insert(PessoasMOD pessoa)
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

        public void Update(PessoasMOD pessoa)
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

        public PessoasMOD ValidaPessoa(PessoasMOD pessoa)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoa.Nome))
                {
                    throw new Exception("Nome não pode ser Em Branco!");
                }

                pessoa.Situacao = pessoa.Ativo ? 1 : 0;

                return pessoa;


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        void IServiceBase<PessoasMOD>.Insert(PessoasMOD entity)
        {
            throw new NotImplementedException();
        }
    }
}
