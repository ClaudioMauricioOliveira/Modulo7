using StoreOfBuild.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRespository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRespository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public void Store(int id, string name, int categoryId, decimal price, int stockQuantity)
        {
            var category = _categoryRepository.GetById(categoryId);
            DomainException.When(category == null, "Category invalid");

            var product = _productRespository.GetById(id);
            if (product == null)
            {
                product = new Product(name, category, price, stockQuantity);
                _productRespository.Save(product);
            }
            else
            {
                product.Update(name, category, price, stockQuantity);
            }
        }
    }
}
