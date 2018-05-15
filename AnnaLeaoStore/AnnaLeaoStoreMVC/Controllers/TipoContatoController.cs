using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnaLeaoStore.Business;

namespace AnnaLeaoStoreMVC.Controllers
{
    public class TipoContatoController : Controller
    {
		private TipoContatoBUS _tipoContatoBUS = new TipoContatoBUS();
        public ActionResult ListarContatos()
        {
			var lista = _tipoContatoBUS.GetAll();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}
