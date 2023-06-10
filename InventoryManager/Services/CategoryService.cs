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
        private DatabaseContext DB { get; set; }

        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        public CategoryModel CategoryToDelete { get; set; } = null;

        public event Action OnStateChange;

        public CategoryService()
        {
            if (DB != null)
            {
                return;
            }

            DB = new DatabaseContext();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public void SetCategoryToDelete(CategoryModel category)
        {
            CategoryToDelete = category;
            NotifyStateChanged();
        }

        public void ClearCategoryToDelete()
        {
            CategoryToDelete = null;
            NotifyStateChanged();
        }

        public async Task<List<CategoryModel>> InitiateCategories()
        {
            Categories = await DB.GetAllCategories();
            NotifyStateChanged();
            return Categories;
        }

        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            CategoryModel newCategory = await DB.AddCategory(category);
            Categories.Add(newCategory);
            NotifyStateChanged();
            return newCategory;
        }

        public List<CategoryModel> GetCategories()
        {
            return Categories;
        }

        public async Task<CategoryModel> EditCategory(CategoryModel category)
        {
            CategoryModel updatedCategory = await DB.EditCategory(category);
            int index = Categories.IndexOf(category);
            Categories[index] = updatedCategory;
            NotifyStateChanged();
            return updatedCategory;
        }

        public async Task<CategoryModel> DeleteCategory(CategoryModel category)
        {
            int res = await DB.DeleteCategory(category);
            Categories.Remove(category);
            NotifyStateChanged();
            return category;
        }

        public async Task DeleteSelectedCategory()
        {
            int res = await DB.DeleteCategory(CategoryToDelete);
            Categories.Remove(CategoryToDelete);
            CategoryToDelete = null;
            NotifyStateChanged();
        }
    }
}
