using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnaLeaoStore.Business;
using AnnaLeaoStoreMVC.Areas.Cadastros.Models;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    public class GradesController : Controller
    {
		private GradesBUS _gradeBUS = new GradesBUS();

		[Authorize]
        public ActionResult ListarGrade()
        {
            try
            {
				List<ModelToVIew> lista = new List<ModelToVIew>();
				foreach (var item in _gradeBUS.GetAll())
                {
                    lista.Add(new ModelToVIew
                    {
                        Codigo = Convert.ToInt32(item.ID),
						Descricao = item.Descricao

                    });
                }

                return PartialView("ConsultaPadrao", lista);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

		[HttpGet]
        [Authorize]
        public ActionResult DetalheGrade(int id)
        {
            try
            {
				var grade = _gradeBUS.GetPorId(id);
                
				return Json(new { status = true, Descricao = grade.Descricao }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
