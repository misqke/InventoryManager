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
        private DatabaseContext DB { get; set; }

        public List<ItemModel> Items { get; set; } = new List<ItemModel>();

        public ItemModel ItemToDelete { get; set; } = null;

        public event Action OnStateChange;

        public ItemService()
        {
            if (DB != null)
            {
                return;
            }

            DB = new DatabaseContext();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public void SetItemToDelete(ItemModel item)
        {
            ItemToDelete = item;
            NotifyStateChanged();
        }

        public void ClearItemToDelete()
        {
            ItemToDelete = null;
            NotifyStateChanged();
        }

        public async Task<List<ItemModel>> InitiateItems()
        {
            Items = await DB.GetAllItems();
            NotifyStateChanged();
            return Items;
        }

        public async Task<ItemModel> AddItem(ItemModel item)
        {
            ItemModel newItem = await DB.AddItem(item);
            Items.Add(newItem);
            NotifyStateChanged();
            return newItem;
        }

        public List<ItemModel> GetItems()
        {
            return Items;
        }

        public async Task<ItemModel> EditItem(ItemModel item)
        {
            ItemModel updatedItem = await DB.EditItem(item);
            int index = Items.IndexOf(item);
            Items[index] = updatedItem;
            NotifyStateChanged();
            return updatedItem;
        }

        public async Task<ItemModel> DeleteItem(ItemModel item)
        {
            int res = await DB.DeleteItem(item);
            Items.Remove(item);
            NotifyStateChanged();
            return item;
        }

        public async Task DeleteSelectedItem()
        {
            int res = await DB.DeleteItem(ItemToDelete);
            Items.Remove(ItemToDelete);
            ItemToDelete = null;
            NotifyStateChanged();
        }
    }
}
