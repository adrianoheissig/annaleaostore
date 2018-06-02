using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using AnnaLeaoStoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

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

                /**
                 * Vou buscar todos os Tipos de Contato e fazer um left join na tabela Contatos
                **/

				var lista = _contatoBUS.GetTiposContatoLeftContatoPorCliente(id);

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
        public ActionResult Salvar(IEnumerable<ContatosViewModel> contatosViewModel)
		{
			try
			{
                List<Contatos> contatos = new List<Contatos>();

                foreach (var item in contatosViewModel)
                {
                    contatos.Add(new Contatos
                    {
                        ID = item.ID,
                        Descricao = item.Descricao,
                        Pessoas = new Pessoas { ID = item.Pessoa_ID },
                        TipoDeContato = new TipoDeContato { ID = item.TipoDeContato_ID }
                    });
                }
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