using AV2Rafael.Models;
using AV2Rafael.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AV2Rafael.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private ServiceProduto _ServiceProduto;
        public ProdutoController()
        {
            _ServiceProduto = new ServiceProduto();
        }

        public async Task<IActionResult> Index()
        {
            var listaProdutos = await _ServiceProduto.oRepositoryProduto.SelecionarTodosAsync();
            return View(listaProdutos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(id);

            return View(produto);
        }

        public ActionResult Create()
        {
            CarregaListaCategorias();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<Produto> ListaProdutos)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in ListaProdutos)
                {
                    item.DataCriacao = DateTime.Now;
                }

                await _ServiceProduto.oRepositoryProduto.IncluirAsync(ListaProdutos);

                return View();
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(id);
            CarregaListaCategorias();
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoSalvo = await _ServiceProduto.oRepositoryProduto.AlterarAsync(produto);
                return View(produtoSalvo);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(id);

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Produto produto)
        {
            await _ServiceProduto.oRepositoryProduto.ExcluirAsync(produto);
            return RedirectToAction("Index");

        }

        public void CarregaListaCategorias()
        {
            ViewData["IdCategoria"] = new SelectList(_ServiceProduto.oRepositoryCategoria.SelecionarTodos(), "IdCategoria", "Nome");
        }
    }
}
