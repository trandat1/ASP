using AssimentASP.Common;
using AssimentASP.Contracts;
using AssimentASP.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssimentASP.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _repo.Create(product);
            TempData["Message"] = $"Added na ung product na {product.Name}";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _repo.Update(product.Id, new { product.Name, product.Description });
            TempData["Message"] = $"Update na ung product na {product.Name}";

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Index(PaginatedRequest request)
        {
            var products = await _repo.GetPaginated(
                request.PageNuumber,
                PaginatedRequest.ITEMS_PER_PAGE,
                request.SearchKeyword ?? string.Empty);
            products.SearchKeyword=request.SearchKeyword;
            return View(products);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _repo.GetOne(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repo.GetOne(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            await _repo.Delete(id);
            TempData["Message"] = $"Delete na ung product na {id}";

            return RedirectToAction("Index");
        }
    }
}
