using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnaLeaoStoreMVC.Controllers
{
	public class ContatosController : Controller
	{
		private ContatosBUS _contatoBUS = new ContatosBUS();
		// GET: Contatos
		public ActionResult ListarPorIdCliente(int id)
		{
			try
			{
				var lista = _contatoBUS.GetID(id);
				//return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

				return new JsonResult { Data = new { sucesso = true, data = lista } };
			}
			catch (Exception ex)
			{
				return new JsonResult { Data = new { sucesso = false, mensagem = ex.Message } };
			}
		}

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

		public ActionResult Salvar(ContatosMOD contatos)
		{
			try
			{
				_contatoBUS.Inserir(contatos);
				return new JsonResult { Data = new { sucesso = true } };
			}
			catch (Exception ex)
			{
				return new JsonResult { Data = new { sucesso = false, ex.Message } };
			}

		}
	}
}