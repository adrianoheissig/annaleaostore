using AnnaLeaoStore.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    public class PrecosItensController : Controller

    {
        PrecosItensBUS _precosItemBUS = new PrecosItensBUS();

        // GET: Cadastros/PrecosItens
        public ActionResult ListarItens(int id)
        {
            var lista = _precosItemBUS.GetAll(id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }
    }
}