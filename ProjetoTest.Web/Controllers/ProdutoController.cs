using System.Web.Mvc;
using ProjetoTest.Aplicacao;
using ProjetoTest.Dominio;

namespace ProjetoTest.Web.Controllers
{
    public class ProdutoController : Controller
    {
        protected readonly ProdutoApp _produto;
        public ProdutoApp ProdutoApp()
        {
            return _produto != null ? _produto : new ProdutoApp();
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtos = ProdutoApp().Lista();
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
                ProdutoApp().Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Editar(int id)
        {
            var produto = ProdutoApp().ListarId(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutoApp().Salvar(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Detalhes(int id)
        {
            var produto = ProdutoApp().ListarId(id);
            return View(produto);
        }


        public ActionResult Excluir(int id)
        {
            var produto = ProdutoApp().ListarId(id);
            ProdutoApp().Excluir(produto.Id);
            return RedirectToAction("Index");
        }

        
    }
}