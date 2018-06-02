using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using System;
using System.Web.Mvc;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    public class PrecosController : Controller
    {
		private PrecosBUS _precosBus = new PrecosBUS();
		private ListaPrecos _precosMOD = new ListaPrecos();

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
				ListaPrecos preco = new ListaPrecos();
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
		public ActionResult Atualizar(ListaPrecos preco)
        {
            try
            {
				if (preco.ID > 0)
                {
                    //Atualizar
					_precosBus.Update(preco);
                    _precosMOD.ID = preco.ID;

                }
                else
                {
                    //Novo
					_precosMOD = _precosBus.Insert(preco);
                }

                return new JsonResult { Data = new { status = true, data = _precosMOD.ID } };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new { status = false, responseText = e.Message } };
            }
        }

    }
}
