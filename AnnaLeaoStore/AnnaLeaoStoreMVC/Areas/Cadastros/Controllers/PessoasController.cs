using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using AnnaLeaoStoreMVC.ViewModels;


namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    //[Authorize]
    public class PessoasController : Controller
    {

        private PessoasBUS _pessoasBUS = new PessoasBUS();
        private ContatosBUS _contatosBUS = new ContatosBUS();

        [Authorize]
        public ActionResult Clientes()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedores()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Listar(int tipo)
        {
            var pessoas = _pessoasBUS.GetAll(tipo);

            var pessoasViewModel = Mapper.Map<List<Pessoas>, List<PessoasViewModel>>(pessoas);

            pessoasViewModel.ForEach(s => s.DescricaoSituacao = s.Situacao == 1 ? "Ativo" : "Inativo");

            return Json(new { data = pessoasViewModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DetalhesPessoa(int id)
        {
            var pessoa = _pessoasBUS.GetByID(id);

            var pessoaViewModel = Mapper.Map<Pessoas, PessoasViewModel>(pessoa);

            pessoaViewModel.DescricaoSituacao = pessoaViewModel.Situacao == 1 ? "Ativo" : "Inativo";

            return View(pessoaViewModel);
        }


        [Authorize]
        public ActionResult Deletar(int id)
        {
            try
            {
                _pessoasBUS.Delete(new Pessoas { ID = id });
                return Json(new { success = true, responseText = "Os dados do Cliente Foram Excluídos com Sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, responseText = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult CadastrarCliente(int id)
        {
            Pessoas pessoa = new Pessoas();
            if (id > 0)
            {
                pessoa = _pessoasBUS.GetByID(id);
            }
            var pessoaViewModel = Mapper.Map<Pessoas, PessoasViewModel>(pessoa);

            pessoaViewModel.Ativo = pessoa.Situacao == 1 ? true : false;

            return View(pessoaViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CadastrarFornecedor(int id)
        {
            Pessoas pessoa = new Pessoas();

            if (id > 0)
            {
                pessoa = _pessoasBUS.GetByID(id);
            }

            var pessoaViewModel = Mapper.Map<Pessoas, PessoasViewModel>(pessoa);

            pessoaViewModel.Ativo = pessoa.Situacao == 1 ? true : false;

            return View(pessoaViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Atualizar(PessoasViewModel pessoaViewModel)
        {
            try
            {

                var pessoa = Mapper.Map<PessoasViewModel, Pessoas>(pessoaViewModel);

                pessoa.Situacao = pessoaViewModel.Ativo ? 1 : 0;

                Pessoas newPessoa = new Pessoas();

                if (pessoa.ID > 0)
                {
                    //Atualizar
                    _pessoasBUS.Update(pessoa);
                    newPessoa.ID = pessoa.ID;
                }
                else
                {
                    //Novo
                    newPessoa = _pessoasBUS.Insert(pessoa);
                }

                return new JsonResult { Data = new { status = true, ID = newPessoa.ID } };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new { status = false, responseText = e.Message } };
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult ListarFornecedores()
        {
            try
            {
                var fornecedores = _pessoasBUS.GetAll(2);

                List<PadraoViewModel> lista = new List<PadraoViewModel>();

                fornecedores.ForEach(s => lista.Add(new PadraoViewModel { Codigo = s.ID, Descricao = s.Nome }));

                return PartialView("ConsultaPadrao", lista);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            //return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DetalheFornecedorNome(int id)
        {
            try
            {
                var pessoa = _pessoasBUS.GetByID(id);

				if (pessoa.TipoPessoa != 2)
				{
					throw new Exception("Nao Encontrado");
				}

				return Json(new { status = true, Nome = pessoa.Nome }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, responseText = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }

}
