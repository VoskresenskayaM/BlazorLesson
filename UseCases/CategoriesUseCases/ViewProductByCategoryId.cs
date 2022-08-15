using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfasces;

namespace UseCases
{
    public class ViewProductByCategoryId : IViewProductByCategoryId
    {
        private readonly IProductRepository iproductRepository;

        public ViewProductByCategoryId(IProductRepository iproductRepository)
        {
            this.iproductRepository = iproductRepository;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return iproductRepository.GetProductByCategoryId(categoryId);
        }

    }

}
