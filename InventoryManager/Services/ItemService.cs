using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Data;

namespace InventoryManager.Services
{
    public class ItemService
    {
        private DatabaseContext db { get; set; }

        public event Action OnStateChange;

        public ItemService()
        {
            if (db != null)
            {
                return;
            }

            db = new DatabaseContext();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public async Task<ItemModel> AddItem(ItemModel item)
        {
            ItemModel newItem = await db.AddItem(item);
            return newItem;
        }

        public async Task<List<ItemModel>> GetItems()
        {
            List<ItemModel> items = await db.GetAllItems();
            return items;
        }

        public async Task<ItemModel> EditItem(ItemModel item)
        {
            ItemModel updatedItem = await db.EditItem(item);
            return updatedItem;
        }

        public async Task<ItemModel> DeleteItem(ItemModel item)
        {
            int res = await db.DeleteItem(item);
            return item;
        }
    }
}
