using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnnaLeaoStore.UI.Controllers
{
    public class LoginController : Controller
    {
        private CadUsuBUS _negocio;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CadUsuMOD login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                _negocio = new CadUsuBUS();
                if (_negocio.Acesso(login))
                {
                    FormsAuthentication.SetAuthCookie(login.Usuario, false);
                    if (Url.IsLocalUrl(returnUrl)
                    && returnUrl.Length > 1
                    && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//")
                    && returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    /*código abaixo cria uma session para armazenar o nome do usuário*/
                    Session["Nome"] = login.Usuario;
                    /*retorna para a tela inicial do Home*/
                    return RedirectToAction("Index", "Home");

                }
            }

            return View(login);
        }

    }

}
