using Ecommerce.System.Ecommerce.Contracts.DALContracts;
using Ecommerce.System.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.System.Ecommerce.DataAccessLayer
{
    public class ProductDAL:ProductDALBase
    {
        //add 
        public override bool AddProductDAL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                products.Add(newProduct);
                productAdded = true;
            }
            catch (Exception)
            {
              
            }
            return productAdded;

        }

       


        //list products
        public override List<Product> GetAllProductsDAL()
        {
            return products;
        }

        //get by id 
        public override Product GetProductByProductIDDAL(Guid searchProductID)
        {
            Product matchingProduct = null;
            try
            {
                //Find Product based on searchProductID
                matchingProduct = ProductDALBase.products.Find(
                    (item) => { return item.ProductID == searchProductID; }
                );
            }
            catch (Exception)
            {
                
            }
            return matchingProduct;
        }

        //get by name 
        public override Product GetProductByProductNameDAL(string productName)
        {
            Product matchingProduct = null;
            try
            {
                //Find Product based on productName
                matchingProduct = ProductDALBase.products.Find(
                    (item) => { return item.ProductName == productName; }
                );
            }
            catch (Exception)
            {

            }
            return matchingProduct;
        }

        //get by number
        public override Product GetProductByProductNumberDAL(int productNumber)
        {
            Product matchingProduct = null;
            try
            {
                //Find Product based on productNumber
                matchingProduct = ProductDALBase.products.Find(
                    (item) => { return item.ProductNumber == productNumber; }
                );
            }
            catch (Exception)
            {

            }
            return matchingProduct;
        }


        //remove
        public override bool RemoveProductDAL(Guid productID)
        {
            bool productRemoved = false;
            try
            {
                Product matchingProduct = GetProductByProductIDDAL(productID);
                if (matchingProduct != null)
                {
                    products.Remove(matchingProduct);
                    productRemoved = true;
                }
                    
            }
            catch (Exception)
            {
                
            }
            return productRemoved;
        }

      


        //update
        public override bool UpdateProductDAL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                //Find Product based on ProductID
                Product matchingProduct = GetProductByProductIDDAL(updateProduct.ProductID);

                if (matchingProduct != null)
                {
                    //Update product details
                    for (int i = 0; i < products.Count; i++)
                    {
                        if(products[i].ProductID == matchingProduct.ProductID)
                        {
                            matchingProduct.ProductName = updateProduct.ProductName;
                            matchingProduct.ProductDescription = updateProduct.ProductDescription;
                            matchingProduct.PriceOfProduct = updateProduct.PriceOfProduct;
                            matchingProduct.Stock = updateProduct.Stock;
                        }                  
                    }
                    productUpdated = true;
                }
            }
            catch (Exception)
            {
                
            }
            return productUpdated;
        }

        
    }
}
