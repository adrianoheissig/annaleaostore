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
    public class ProdutosController : Controller
    {
		private ProdutosBUS _produtosBus = new ProdutosBUS();

		public ActionResult ListarProdutos(){
			var produtos = _produtosBus.GetAll();
			return View(produtos);
			//return Json(new { data = produtos }, JsonRequestBehavior.AllowGet);

		}

		public ActionResult Deletar(int id){
			try
			{
				_produtosBus.Delete(id);
				return Json(new { success = true, responseText = "Os dados do Produto Foram Excluídos com Sucesso!" }, JsonRequestBehavior.AllowGet);

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
			ProdutosMOD produto = new ProdutosMOD();
            if (id > 0)
            {
				produto = _produtosBus.GetByID(id);
            }

			return View(produto);
        }
        
		[HttpPost]
        [Authorize]
		public ActionResult Salvar(ProdutosMOD produto)
        {
            try
            {
                if (produto.ID > 0)
                {
                    //Atualizar
					_produtosBus.Update(produto);
                }
                else
                {
                    //Novo
					_produtosBus.Insert(produto);
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
