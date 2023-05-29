using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Data;

namespace InventoryManager.Services
{
    public class CategoryService
    {
        private DatabaseContext db { get; set; }

        public CategoryService()
        {
            if (db != null)
            {
                return;
            }

            db = new DatabaseContext();
        }

        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            CategoryModel newCategory = await db.AddCategory(category);
            return newCategory;
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            List<CategoryModel> categories = await db.GetAllCategories();
            return categories;
        }

        public async Task<CategoryModel> EditCategory(CategoryModel category)
        {
            CategoryModel updatedCategory = await db.EditCategory(category);
            return updatedCategory;
        }

        public async Task<CategoryModel> DeleteCategory(CategoryModel category)
        {
            int res = await db.DeleteCategory(category);
            return category;
        }
    }
}
