using Ecommerce.System.Ecommerce.Contracts.BLContracts;
using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.DataAccessLayer;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ecommerce.System.Ecommerce.BusinessLayer
{
    public class ProductBL : IProductBL
    {
        ProductDALBase productDALBase;
        public ProductBL()
        {
            this.productDALBase = new ProductDAL();
        }


        //add
        public bool AddProductBL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                productAdded = this.productDALBase.AddProductDAL(newProduct);
            }
            catch (Exception)
            {

                throw;
            }
            return productAdded;
        }


        //get all 
        public List<Product> GetAllProductsBL()
        {
            List<Product> products = null;
            try
            {
                products = this.productDALBase.GetAllProductsDAL();
            }
            catch (Exception)
            {

                throw;
            }
            return products;
        }


        //get by id
        public Product GetProductByProductIDBL(Guid searchProductID)
        {
            Product product = null;
            try
            {
                product = this.productDALBase.GetProductByProductIDDAL(searchProductID);
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }


        //get by name
        public Product GetProductByProductNameBL(string productName)
        {
            Product product = null;
            try
            {
                product = this.productDALBase.GetProductByProductNameDAL(productName);
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }


        //get by number
        public Product GetProductByProductNumberBL(int productNumber)
        {
            Product product = null;
            try
            {
                product = this.productDALBase.GetProductByProductNumberDAL(productNumber);
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }


        //remove 
        public bool RemoveProductBL(Guid productID)
        {
            bool productRemoved = false;
            try
            {
                productRemoved = this.productDALBase.RemoveProductDAL(productID);
            }
            catch (Exception)
            {

                throw;
            }
            return productRemoved;
        }


        //update
        public bool UpdateProductBL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                productUpdated = this.productDALBase.UpdateProductDAL(updateProduct);
            }
            catch (Exception)
            {

                throw;
            }
            return productUpdated;
        }
    }
}
