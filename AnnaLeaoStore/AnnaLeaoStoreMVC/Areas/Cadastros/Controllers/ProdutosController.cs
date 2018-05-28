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
			return Json(new { data = produtos }, JsonRequestBehavior.AllowGet);

		}

        public ActionResult Consulta()
        {
            return View();
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
			try
			{

				Produtos produto = new Produtos();
                produto.Grade = new Grade();
                produto.Pessoas = new Pessoas();
                if (id > 0)
                {
                    produto = _produtosBus.GetByID(id);
                }

                if (produto == null)
				{
					throw new Exception("Produto Não Encontrado!");
				}
				return View(produto);

			}
			catch (Exception ex)
			{
				return ViewBag(ex.Message);
			}
        }
        
		[HttpPost]
        [Authorize]
		public ActionResult Atualizar(Produtos produto)
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

		[HttpGet]
        [Authorize]
        public ActionResult Detalhes(int id)
        {
			var produto = _produtosBus.GetByID(id);

            return View(produto);
        }


    }
}