using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InventoryManager.Data
{
    [Table("categories")]
    public class CategoryModel : DbItem
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
