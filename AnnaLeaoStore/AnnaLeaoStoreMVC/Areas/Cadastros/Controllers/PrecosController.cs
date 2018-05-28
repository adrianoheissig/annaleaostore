using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
	public class PrecosController : Controller
    {
		private PrecosBUS _precosBus = new PrecosBUS();
		private ListaPrecosMOD _precosMOD = new ListaPrecosMOD();


		public ActionResult Consulta()
        {
            return View();
        }

		public ActionResult ListarPrecos(){
			try
			{
				var precos = _precosBus.GetAll();
                return Json(new { data = precos }, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				return Json(new { status = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
			}

		}

		public ActionResult Deletar(int id){
			try
			{
				_precosBus.Deletar(id);
				return Json(new { success = true, responseText = "A tabela de Preço foi Excluída com Sucesso!" }, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
        [Authorize]
        public ActionResult Cadastrar(int id)
        {
			try
			{
				ListaPrecosMOD preco = new ListaPrecosMOD();
                if (id > 0)
                {
					preco = _precosBus.GetById(id);
                }

				if (preco == null)
				{
					throw new Exception("Preço Não Encontrado!");
				}
				return View(preco);

			}
			catch (Exception ex)
			{
				return ViewBag(ex.Message);
			}
        }
        
		[HttpPost]
        [Authorize]
		public ActionResult Atualizar(ListaPrecosMOD preco)
        {
            try
            {
				if (preco.ID > 0)
                {
                    //Atualizar
					_precosBus.Update(preco);

                }
                else
                {
                    //Novo
					_precosMOD = _precosBus.Insert(preco);
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
