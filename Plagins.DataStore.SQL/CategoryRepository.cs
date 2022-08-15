using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfasces;

namespace Plagins.DataStore.SQL


{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategoryRepository(MarketContext db )
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
        
            db.Categorys.Add(category);
            db.SaveChanges();
        
            
        }

        public void DeleteCategory(int categoryId)
        {
            Category  ? DeliteCategory = db.Categorys.Find(categoryId);
            if (DeliteCategory == null) return;
            else
            {
                db.Categorys.Remove(DeliteCategory);
            }
            db.SaveChanges();



        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categorys.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            
                return db.Categorys.Find(categoryId);

        }

        public void UpdateCategory(Category category)
        {
            Category updateCategory = db.Categorys.Find(category.CategoryId);
                if (updateCategory != null)
            {
                updateCategory.Name = category.Name;
                updateCategory.Description = category.Description;
                updateCategory.Products = category.Products;

                db.SaveChanges();
            }
        }
    }
}
