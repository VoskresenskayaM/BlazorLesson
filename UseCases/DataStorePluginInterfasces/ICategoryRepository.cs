using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfasces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        void AddCategory(Category category);

        void UpdateCategory(Category category);
        public Category GetCategoryById(int categoryId);
        public void DeleteCategory(int categoryId);
    }
}
