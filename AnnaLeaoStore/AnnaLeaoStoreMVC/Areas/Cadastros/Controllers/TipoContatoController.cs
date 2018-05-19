using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnaLeaoStore.Business;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    public class TipoContatoController : Controller
    {
		private TipoContatoBUS _tipoContatoBUS = new TipoContatoBUS();
        public ActionResult ListarContatos()
        {
			try
			{
				var lista = _tipoContatoBUS.GetAll();
				return Json(new { success = true, data = lista }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				return Json(new { success = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
			}

        }
    }
}
