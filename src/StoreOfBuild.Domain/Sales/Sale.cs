using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain.Sales
{
    public class Sale: Entity
    {
        public string ClienteName { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public decimal Total { get; set; }
        public SaleItem Item { get; set; }

        private Sale() { }

        public Sale(string clientName, Product product, int quantity)
        {
            DomainException.When(string.IsNullOrEmpty(clientName), "Client name is required");
            Item = new SaleItem(product, quantity);
            CreatedOn = DateTime.Now;
            ClienteName = clientName;
        }
    }
}
