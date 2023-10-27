using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web_ECommerce.Controllers
{
    public class ProdutosController : Controller
    {
        protected readonly IProdutoApp _produtoApp;
        public ProdutosController(IProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
        }

        // GET: ProdutosController
        public async Task<IActionResult> Index()
        {
            return View(await _produtoApp.List());
        }

        // GET: ProdutosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _produtoApp.GetEntityById(id));
        }

        // GET: ProdutosController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            try
            {
                await _produtoApp.AddProduto(produto);

                if (produto.Notifications.Any())
                {
                    foreach(var notification in produto.Notifications)
                    {
                        ModelState.AddModelError(notification.PropertyName, notification.Message);
                    }

                    return View("Edit", produto);
                }
            }
            catch
            {
                return View("Edit", produto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _produtoApp.GetEntityById(id));

        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            try
            {
                await _produtoApp.UpdateProduto(produto);

                if (produto.Notifications.Any())
                {
                    foreach (var notification in produto.Notifications)
                    {
                        ModelState.AddModelError(notification.PropertyName, notification.Message);
                    }

                    return View("Edit", produto);
                }
            }
            catch
            {
                return View("Edit", produto);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProdutosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _produtoApp.GetEntityById(id));
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            try
            {
                var produtoDeletar = await _produtoApp.GetEntityById(id);

                await _produtoApp.Delete(produtoDeletar);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
