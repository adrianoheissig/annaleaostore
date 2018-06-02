using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class PessoasREP
    {
        private DBContext db = new DBContext();

        public void Delete(Pessoas pessoa)
        {
            try
            {
                db.PessoasMOD.Remove(pessoa);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Pessoas> GetAll(int tipo)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.PessoasMOD.Where(s => (int)s.TipoPessoa == tipo).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pessoas GetByID(int id)
        {
            try
            {
                return db.PessoasMOD.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pessoas Insert(Pessoas pessoa)
        {
            try
            {
                db.PessoasMOD.Add(pessoa);
                db.SaveChanges();
                return pessoa;
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
                var pessoaORI = db.PessoasMOD.Find(pessoa.ID);

                pessoaORI.Nome = pessoa.Nome;
                pessoaORI.Endereco = pessoa.Endereco;
                pessoaORI.Bairro = pessoa.Bairro;
                pessoaORI.Cidade = pessoa.Cidade;
                pessoaORI.Estado = pessoa.Estado;
                pessoaORI.Cep = pessoa.Cep;
                pessoaORI.Pais = pessoa.Pais;
                pessoaORI.Situacao = pessoa.Situacao;
                pessoaORI.Observacao = pessoa.Observacao;
                pessoaORI.TipoPessoa = pessoa.TipoPessoa;
                pessoaORI.DataNascimento = pessoa.DataNascimento;
                pessoaORI.EnderecoEntrega = pessoa.EnderecoEntrega;
                pessoaORI.BairroEntrega = pessoa.BairroEntrega;
                pessoaORI.CidadeEntrega = pessoa.CidadeEntrega;
                pessoaORI.EstadoEntrega = pessoa.EstadoEntrega;
                pessoaORI.CepEntrega = pessoa.CepEntrega;
                pessoaORI.PaisEntrega = pessoa.PaisEntrega;
                pessoaORI.NomeDestinatario = pessoa.NomeDestinatario;

                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
