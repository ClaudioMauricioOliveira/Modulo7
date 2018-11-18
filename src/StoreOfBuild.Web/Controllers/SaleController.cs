using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize(Roles = "Admin, Operation")]
    public class SaleController : Controller
    {
        private readonly SaleFactory _saleFactory;
        private readonly IRepository<Product> _productRepository;

        public SaleController(SaleFactory saleFactory, IRepository<Product> productRepository)
        {
            _saleFactory = saleFactory;
            _productRepository = productRepository;
        }

        public IActionResult Create()
        {
            var products = _productRepository.All();
            if (products.Any())
            {
                var productViewModel = products.Select(p => new ProductViewModel { Id = p.Id, Name = p.Name });
                return View(new SaleViewModel { Products = productViewModel });
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(SaleViewModel viewModel)
        {
            _saleFactory.Create(viewModel.ClientName, viewModel.ProductId, viewModel.Quantity);
            return Ok();
        }
    }
}