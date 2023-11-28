using AV2Rafael.Models;
using AV2Rafael.Repositories;
using AV2Rafael.Service;
using Microsoft.AspNetCore.Mvc;

namespace AV2Rafael.Controllers
{
    public class CategoriaController : Controller
    {
        private ServiceCategoria _ServiceCategoria;

        public CategoriaController()
        {
            _ServiceCategoria = new ServiceCategoria();
        }

        public async Task<IActionResult> Index()
        {
            var listaCategoriaes = await _ServiceCategoria.oRepositoryCategoria.SelecionarTodosAsync();
            return View(listaCategoriaes);
        }
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _ServiceCategoria.oRepositoryCategoria.SelecionarPkAsync(id);

            return View(categoria);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.DataCriacao = DateTime.Now;
                var categoriaSalvo = await _ServiceCategoria.oRepositoryCategoria.IncluirAsync(categoria);
                return View(categoriaSalvo);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View(categoria);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _ServiceCategoria.oRepositoryCategoria.SelecionarPkAsync(id);
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var categoriaSalvo = await _ServiceCategoria.oRepositoryCategoria.AlterarAsync(categoria);
                return View(categoriaSalvo);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _ServiceCategoria.oRepositoryCategoria.SelecionarPkAsync(id);

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Categoria categoria)
        {
            await _ServiceCategoria.oRepositoryCategoria.ExcluirAsync(categoria);
            return RedirectToAction("Index");

        }
    }
}