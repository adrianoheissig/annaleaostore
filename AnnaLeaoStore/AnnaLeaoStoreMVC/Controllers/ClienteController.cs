using System.Web.Mvc;
using Impacta.LojasTakararo.Model;
using Impacta.LojasTakararo.Business;
using System;

namespace Impacta.LojasTakararo.UI.MVC.Controllers
{
    public class UsuarioController : Controller
    {

        //Todas actions que retorna tela para cima, retorna com HttPost para baixo
        // A view tem que receber apenas MODELOS

        private UsuarioBUS _negocio = new UsuarioBUS();
        private CursoBUS _negocioCurso = new CursoBUS();

        // GET: Usuario

        public ActionResult Cadastro()
        {
            return View();
        }

        //mvcaction4 tab tab
        public ActionResult Listar()
        {
            //Criamos um objeto que pode armazenar dados, porém o tempo de vida é apenas de uma ida e uma volta {ViewBag}

            ViewBag.Cursos = _negocioCurso.Listar(); // ele nao possui intelisense , ele só existe em tempo de execução.

            return View(_negocio.Listar());
        }

        public ActionResult Deletar(Int32 codigo) // Nome da Variavel tem que ser igual o da pagina cshtml
        {
            try
            {
                _negocio.Deletar(codigo);
                TempData.Add("Sucesso", "Usuário Deletado com Sucesso!");

            }
            catch (Exception ex)
            {

                TempData.Add("Erro", ex.Message);
            }

            return RedirectToAction("Listar"); //Quando for uma view TIPADA , deve ser redirecionada
        }

        public ActionResult Inativar(Int32 codigo) // Nome da Variavel tem que ser igual o da pagina cshtml
        {
            try
            {
                _negocio.Inativar(codigo);
                TempData.Add("Sucesso", "Usuário Inativado com Sucesso!");

            }
            catch (Exception ex)
            {

                TempData.Add("Erro", ex.Message);
            }

            return RedirectToAction("Listar"); //Quando for uma view TIPADA , deve ser redirecionada
        }

        public ActionResult Editar(Int32 codigo)
        {
            return View(_negocio.Editar(codigo));
        }

        //mvcpostaction4 tab tab
        [HttpPost]
        public ActionResult Cadastrar(FormCollection dados)
        {
            try
            {
                UsuarioMOD novoUsuario = new UsuarioMOD();

                novoUsuario.Usuario = dados["usuario"];
                novoUsuario.Senha = dados["senha"];

                _negocio.Cadastrar(novoUsuario);
                TempData.Add("Sucesso", $"Usuário: {novoUsuario.Usuario} Criado com Sucesso!");
            }
            catch (Exception ex)
            {
                //Criamos um TEMP de Data de Erro
                TempData.Add("Erro", ex.Message);
            }

            return View("Cadastro");
        }

        [HttpPost]
        public ActionResult Atualizar(FormCollection dados)
        {
            try
            {
                UsuarioMOD usuario = new UsuarioMOD();
                usuario.Codigo = Convert.ToInt32(dados["codigo"]);
                usuario.Usuario = dados["usuario"];
                usuario.Senha = dados["senha"];
                _negocio.Atualizar(usuario);

                TempData.Add("Sucesso", "Usuario atualizado com Sucesso!");

            }
            catch (Exception ex)
            {

                TempData.Add("Erro", ex.Message);
            }

            //return RedirectToAction("Listar");

            return RedirectToAction("Editar", "usuario", new { codigo = Convert.ToInt32(dados["codigo"]) });
        }

    }
}