using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfasces;

namespace Plagins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductRepository(MarketContext db )
        {
            this.db = db;
        }
        
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Product deleteProduct = db.Products.Find(product.ProductId);
            if (deleteProduct == null) return;
          
                db.Products.Remove(product);
            
            db.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            var findProducts = db.Products.Where(x => x.CategoryId == categoryId);
            return findProducts.ToList();

        }

        public Product GetProductById(int productId)
        {
           return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
           return db.Products.ToList() ;
        }

        public void UpdateProduct(Product product)
        {
            Product updateProduct = db.Products.Find(product.ProductId);
            if (updateProduct == null) return;
            updateProduct.Name = product.Name;
            updateProduct.Quantity = product.Quantity;
            updateProduct.Price = product.Price;
            updateProduct.CategoryId = product.CategoryId;
            db.SaveChanges();
        }
    }
}
