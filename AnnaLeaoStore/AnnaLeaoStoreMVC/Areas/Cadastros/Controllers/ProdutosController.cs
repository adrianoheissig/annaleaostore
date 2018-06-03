using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using AutoMapper;
using AnnaLeaoStoreMVC.ViewModels;

namespace AnnaLeaoStoreMVC.Areas.Cadastros.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosBUS _produtosBus = new ProdutosBUS();
        private EstoqueBUS _estoqueBUS = new EstoqueBUS();

        public ActionResult Consulta()
        {
            return View();
        }

        public ActionResult ListarProdutos()
        {
            var produtos = _produtosBus.GetAll();

            var produtosViewModel = Mapper.Map<List<Produtos>, List<ProdutosViewModel>>(produtos);

            foreach (var item in produtosViewModel)
            {
                item.DescSituacao = item.Situacao == 1 ? "Ativo" : "Inativo";
                item.QtdeEstoque = _estoqueBUS.TotalEstoquePorProduto((int)item.ID);
                item.NomeFornecedor = item.Pessoas.Nome;
                item.Pessoas = null;
            }

            return Json(new { data = produtosViewModel }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deletar(int id)
        {
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

                produto.Grades = new Grades();
                produto.Pessoas = new Pessoas();

                if (id > 0)
                {
                    produto = _produtosBus.GetByID(id);
                }

                if (produto == null)
                {
                    throw new Exception("Produto Não Encontrado!");
                }
                var produtoViewModel = Mapper.Map<Produtos, ProdutosViewModel>(produto);

                produtoViewModel.Ativo = produtoViewModel.Situacao == 1 ? true : false;

                return View(produtoViewModel);

            }
            catch (Exception ex)
            {
                return ViewBag(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Atualizar(ProdutosViewModel produtoViewModel)
        {
            try
            {
                var produto = Mapper.Map<ProdutosViewModel, Produtos>(produtoViewModel);

                produto.Situacao = produtoViewModel.Ativo ? 1 : 0;

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

            var produtosViewModel = Mapper.Map<Produtos, ProdutosViewModel>(produto);

            produtosViewModel.DescSituacao = produtosViewModel.Situacao == 1 ? "Ativo" : "Inativo";

            produtosViewModel.Estoque = _estoqueBUS.EstoqueDoProduto(id);

            if (produtosViewModel.Grades.Tam1 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam1); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam1); }
            if (produtosViewModel.Grades.Tam2 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam2); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam2); }
            if (produtosViewModel.Grades.Tam3 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam3); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam3); }
            if (produtosViewModel.Grades.Tam4 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam4); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam4); }
            if (produtosViewModel.Grades.Tam5 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam5); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam5); }
            if (produtosViewModel.Grades.Tam6 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam6); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam6); }
            if (produtosViewModel.Grades.Tam7 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam7); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam7); }
            if (produtosViewModel.Grades.Tam8 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam8); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam8); }
            if (produtosViewModel.Grades.Tam9 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam9); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam9); }
            if (produtosViewModel.Grades.Tam10 != null) { produtosViewModel.NomeGrade.Add(produtosViewModel.Grades.Tam10); produtosViewModel.QtdeTam.Add((decimal)produtosViewModel.Estoque.Tam10); }

            return View(produtosViewModel);
        }

        [Authorize]
        public ActionResult ListarProdutosResumo()
        {
            try
            {
                List<Produtos> produtos = _produtosBus.GetAll();

                List<PadraoViewModel> lista = new List<PadraoViewModel>();

                produtos.ForEach(s => lista.Add(new PadraoViewModel { Codigo = s.ID, Descricao = s.Descricao }));

                return PartialView("ConsultaPadrao", lista);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult DetalheProduto(int id)
        {
            try
            {
                var produto = _produtosBus.GetByID(id);

                return Json(new { status = true, Descricao = produto.Descricao }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}