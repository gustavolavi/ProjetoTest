using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoTest.Aplicacao;
using ProjetoTest.Dominio;

namespace ProjetoTest.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var appProduto = new ProdutoApp();
            var produtos = appProduto.Lista();
            return View(produtos);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var appProduto = new ProdutoApp();
                appProduto.Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Editar(int id)
        {
            var appProduto = new ProdutoApp();
            var produto = appProduto.ListarId(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var appProduto = new ProdutoApp();
                appProduto.Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Detalhes(int id)
        {
            var appProduto = new ProdutoApp();
            var produto = appProduto.ListarId(id);
            return View(produto);
        }


        public ActionResult Excluir(int id)
        {
            var appProduto = new ProdutoApp();
            var produto = appProduto.ListarId(id);
            appProduto.Excluir(produto.Id);
            return RedirectToAction("Index");
        }

        
    }
}