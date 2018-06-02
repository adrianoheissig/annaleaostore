using AnnaLeaoStore.DataAccess;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AnnaLeaoStore.Repository
{
    public class ContatosREP
    {
        private DBContext db = new DBContext();

        public List<Contatos> GetTiposContatoLeftContatoPorCliente(int idPessoa)
        {
            try
            {
                var tipoDeContatosEContatos = (from tipoContato in db.TipoDeContatoMOD
                                               join contato in db.ContatosMOD.Where(x => x.Pessoas.ID == idPessoa) on tipoContato.ID equals contato.TipoDeContato.ID into joined
                                               from j in joined.DefaultIfEmpty()
                                               select new
                                               {
                                                   ID = j.ID,
                                                   Descricao = j.Descricao,
                                                   TipoDeContato = tipoContato
                                               }).ToList();
                                               
                List<Contatos> contatos = new List<Contatos>();
                foreach (var item in tipoDeContatosEContatos)
                {

                    contatos.Add(new Contatos
                    {
                        ID = item.ID ,
                        Descricao = item.Descricao,

                        Pessoas = new Pessoas { ID = idPessoa },
                        TipoDeContato = item.TipoDeContato
                    });
                }

                return contatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Contatos> GetID(int idPessoa)
        {
            try
            {
                List<Contatos> contatos = new List<Contatos>();

                contatos = db.ContatosMOD.Where(s => s.Pessoas.ID == idPessoa).ToList();

                return contatos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Deletar(int id)
        {
            try
            {
                var contatos = db.ContatosMOD.Find(id);
                db.ContatosMOD.Remove(contatos);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(Contatos contatos)
        {
            try
            {
                contatos.TipoDeContato = db.TipoDeContatoMOD.Find(contatos.TipoDeContato.ID);
                contatos.Pessoas = db.PessoasMOD.Find(contatos.Pessoas.ID);
                db.ContatosMOD.Add(contatos);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Contatos contatos)
        {
            try
            {
                var contatosORI = db.ContatosMOD.Find(contatos.ID);

                contatosORI.Descricao = contatos.Descricao;

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
