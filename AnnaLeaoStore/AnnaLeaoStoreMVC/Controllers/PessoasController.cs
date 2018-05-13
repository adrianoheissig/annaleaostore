using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnaLeaoStoreMVC.Controllers
{
    //[Authorize]
    public class PessoasController : Controller
    {

        private PessoasBUS _pessoasBUS = new PessoasBUS();

        public ActionResult Clientes()
        {
            return View();
        }

        public ActionResult Fornecedores()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar(int tipo)
        {
            var lista = _pessoasBUS.GetAll(tipo);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


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
        public ActionResult CadastrarCliente(int id)
        {
            PessoasMOD pessoa = new PessoasMOD();
            if (id > 0)
            {
                pessoa = _pessoasBUS.GetByID(id);
            }

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Atualizar(PessoasMOD pessoa)
        {
            try
            {

                if (pessoa.ID > 0)
                {
                    //Atualizar
                    _pessoasBUS.Update(pessoa);
                }
                else
                {
                    //Novo
                    _pessoasBUS.Insert(pessoa);
                }

                return new JsonResult { Data = new { status = true } };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new { status = false, responseText = e.Message } };
            }
        }
    }

}
