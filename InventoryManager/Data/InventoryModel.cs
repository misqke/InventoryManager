using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InventoryManager.Data
{
    [Table("inventory")]
    public class InventoryModel : DbItem
    {
        [PrimaryKey, AutoIncrement]
        public int InventoryId { get; set; }    

        public int ItemId { get; set; }

        public int LocationId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal OnHand { get; set; }

        public int Order { get; set; }
    }
}
