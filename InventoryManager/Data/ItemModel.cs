using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InventoryManager.Data
{
    [Table("items")]
    public class ItemModel : DbItem
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }

        public int CategoryId { get; set; }

        public string ItemName { get; set; }
    }
}
