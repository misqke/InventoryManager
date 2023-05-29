using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InventoryManager.Data
{
    public class DatabaseContext
    {
        string _dbpath;

        public SQLiteAsyncConnection context;

        private async void Init()
        {
            if (context != null)
            {
                return;
            }

            context = new SQLiteAsyncConnection(_dbpath);
            await context.CreateTableAsync<LocationModel>();
            await context.CreateTableAsync<CategoryModel>();
            await context.CreateTableAsync<ItemModel>();
            await context.CreateTableAsync<InventoryModel>();
        }

        public DatabaseContext()
        {
            _dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "inventory.db3");
            //_dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "inventory.db3");
            Init();
        }

        // Locations
        public async Task<LocationModel> AddLocation(LocationModel location)
        {
            int result = await context.InsertAsync(location);
            return location;
        }

        public async Task<LocationModel> EditLocation(LocationModel location)
        {
            int result = await context.UpdateAsync(location);
            return location;
        }

        public async Task<int> DeleteLocation(LocationModel location)
        {
            int result = await context.DeleteAsync(location);
            return result;
        }

        public async Task<List<LocationModel>> GetAllLocations()
        {
            List<LocationModel> locations = await context.Table<LocationModel>().ToListAsync();
            return locations;
        }

        // Categories
        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            int result = await context.InsertAsync(category);
            return category;
        }

        public async Task<CategoryModel> EditCategory(CategoryModel category)
        {
            int result = await context.UpdateAsync(category);
            return category;
        }

        public async Task<int> DeleteCategory(CategoryModel category)
        {
            int result = await context.DeleteAsync(category);
            return result;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            List<CategoryModel> categories = await context.Table<CategoryModel>().ToListAsync();
            return categories;
        }

        // Items
        public async Task<ItemModel> AddItem(ItemModel item)
        {
            int result = await context.InsertAsync(item);
            return item;
        }

        public async Task<ItemModel> EditItem(ItemModel item)
        {
            int result = await context.UpdateAsync(item);
            return item;
        }

        public async Task<int> DeleteItem(ItemModel item)
        {
            int result = await context.DeleteAsync(item);
            return result;
        }

        public async Task<List<ItemModel>> GetAllItems()
        {

            List<ItemModel> items = await context.Table<ItemModel>().ToListAsync();
            return items;
        }

        // Inventory
        public async Task<InventoryModel> AddInventory(InventoryModel inventory)
        {

            int result = await context.InsertAsync(inventory);
            return inventory;
        }

        public async Task<InventoryModel> EditInventory(InventoryModel inventory)
        {

            int result = await context.UpdateAsync(inventory);
            return inventory;
        }

        public async Task<int> DeleteInventory(InventoryModel inventory)
        {
            int result = await context.DeleteAsync(inventory);
            return result;
        }

        public async Task<List<InventoryModel>> GetMonthInventory(int month, int year, int locationId)
        {
            List<InventoryModel> inventories = await context.Table<InventoryModel>().Where(i => i.Month == month && i.Year == year && i.LocationId == locationId).ToListAsync();
            return inventories;
        }

    }

}