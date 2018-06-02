using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnaLeaoStore.Business;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    public class TipoDeContatoController : Controller
    {
		private TipoDeContatoBUS _TipoDeContatoBUS = new TipoDeContatoBUS();

        [Authorize]
        public ActionResult ListarContatos()
        {
			try
			{
				var lista = _TipoDeContatoBUS.GetAll();
				return Json(new { success = true, data = lista }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { success = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
			}

        }
    }
}
