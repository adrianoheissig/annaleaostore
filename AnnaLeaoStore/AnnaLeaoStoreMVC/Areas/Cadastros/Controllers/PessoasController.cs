﻿using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var lista = _pessoasBUS.GetAll(tipo);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DetalhesPessoa(int id)
        {
			var pessoa = _pessoasBUS.GetByID(id);
			pessoa.Contatos = _contatosBUS.GetID(Convert.ToInt32(pessoa.ID));

            return View(pessoa);
        }


        [Authorize]
        public ActionResult Deletar(int id)
        {
            try
            {
                 _pessoasBUS.Delete(new PessoasMOD { ID = id });
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
            PessoasMOD pessoa = new PessoasMOD();
            if (id > 0)
            {
                pessoa = _pessoasBUS.GetByID(id);
            }

            return View(pessoa);
        }

		[HttpGet]
        [Authorize]
        public ActionResult CadastrarFornecedor(int id)
        {
            PessoasMOD pessoa = new PessoasMOD();
            if (id > 0)
            {
                pessoa = _pessoasBUS.GetByID(id);
            }

            return View(pessoa);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Atualizar(PessoasMOD pessoa)
        {
            try
            {
                PessoasMOD newPessoa = new PessoasMOD();

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
    }

}
