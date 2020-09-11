using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.Contracts.BLContracts
{
    public interface IProductBL
    {
        public Product GetProductByProductIDBL(Guid searchProductID);
        public Product GetProductByProductNameBL(string productName);
        public Product GetProductByProductNumberBL(int productNumber);
        public List<Product> GetAllProductsBL();
        public bool AddProductBL(Product newProduct);
        public bool RemoveProductBL(Guid productID);
        public bool UpdateProductBL(Product updateProduct);
    }
}
