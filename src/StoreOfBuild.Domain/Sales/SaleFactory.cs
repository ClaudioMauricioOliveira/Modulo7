using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain.Sales
{
    public class SaleFactory
    {
        private readonly IRepository<Sale> _SaleRepository;
        private readonly IRepository<Product> _productRepository;

        public SaleFactory(IRepository<Sale> SaleRepository, IRepository<Product> productRepository)
        {
            _SaleRepository = SaleRepository;
            _productRepository = productRepository;
        }

        public void Create(string clientName, int productId, int quantity)
        {
            var product = _productRepository.GetById(productId);
            product.RemoveFromStock(quantity);

            var sale = new Sale(clientName, product, quantity);
            _SaleRepository.Save(sale);
        }
    }
}
