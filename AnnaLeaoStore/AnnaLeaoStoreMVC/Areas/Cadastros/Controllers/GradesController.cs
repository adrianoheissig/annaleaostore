using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using AnnaLeaoStoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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
                List<Grades> grades = _gradeBUS.GetAll();

                List<PadraoViewModel> lista = new List<PadraoViewModel>();

                grades.ForEach(s => lista.Add(new PadraoViewModel { Codigo = s.ID, Descricao = s.Descricao }));

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
				var grade = _gradeBUS.GetById(id);
                
				return Json(new { status = true, Descricao = grade.Descricao }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
