using AnnaLeaoStore.Business;
using AnnaLeaoStore.Model;
using AnnaLeaoStoreMVC.ViewModels;
using AutoMapper;
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
        ProdutosBUS _produtosBUS = new ProdutosBUS();
        PrecosBUS _listaPrecosBUS = new PrecosBUS();

        // GET: Cadastros/PrecosItens
        public ActionResult ListarItens(int id)
        {
            var lista = _precosItemBUS.GetAll(id);
            ViewBag.ListaPrecosID = id;
            return PartialView(lista);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Detalhes(int id)
        {
            var lista = _precosItemBUS.GetAll(id);
            var preco = _listaPrecosBUS.GetById(id);

            ViewBag.Descricao = preco.Descricao;
            ViewBag.Validade = preco.Validade;

            return View(lista);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Atualizar(ListaPrecosItemViewModel precoItemViewModel)
        {
            try
            {
                var precoItem = Mapper.Map<ListaPrecosItemViewModel, ListaPrecosItem>(precoItemViewModel);

                var produto = new Produtos();
                produto.ID = precoItemViewModel.Produtos_ID;
                precoItem.Produtos = produto;

                var listaPreco = new ListaPrecos();
                listaPreco.ID = precoItemViewModel.ListaPrecos_ID;
                precoItem.ListaPrecos = listaPreco;

                _precosItemBUS.Insert(precoItem);
                return new JsonResult { Data = new { status = true } };
            }
            catch (Exception e)
            {
                return new JsonResult { Data = new { status = false, responseText = e.Message } };
            }
        }
        public ActionResult Deletar(int id)
        {
            try
            {
                _precosItemBUS.Deletar(id);
                return new JsonResult { Data = new { status = true } };
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}