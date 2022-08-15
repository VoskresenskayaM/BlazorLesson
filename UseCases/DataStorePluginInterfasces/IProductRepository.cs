using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfasces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        Product GetProductById(int productId);
        public void DeleteProduct(Product product);
        public IEnumerable<Product> GetProductByCategoryId(int category);
    }
}
