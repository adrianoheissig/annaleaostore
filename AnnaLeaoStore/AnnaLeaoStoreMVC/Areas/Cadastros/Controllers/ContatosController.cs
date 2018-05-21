using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
	public class ContatosController : Controller
	{
		private ContatosBUS _contatoBUS = new ContatosBUS();
        // GET: Contatos
        [Authorize]
        [HttpGet]
		public ActionResult ListarPorIdCliente(int id)
		{
			try
			{
				var lista = _contatoBUS.GetID(id);

				return View(lista);
			
			}
			catch (Exception ex)
			{

				return Json(new { sucesso = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
			}
		}

        [Authorize]
        public ActionResult Deletar(int id)
		{
			try
			{
				_contatoBUS.Deletar(id);
				return new JsonResult { Data = new { sucesso = true } };
			}
			catch (Exception ex)
			{
				return new JsonResult { Data = new { sucesso = false, mensagem = ex.Message } };
			}

		}

        [Authorize]
        public ActionResult Salvar(IEnumerable<ContatosMOD> contatos)
		{
			try
			{
				_contatoBUS.Inserir(contatos);
				return new JsonResult { Data = new { status = true } };
			}
			catch (Exception ex)
			{
				return new JsonResult { Data = new { status = false, ex.Message } };
			}

		}
	}
}