using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace InventoryManager.Data
{
    [Table("locations")]
    public class LocationModel : DbItem
    {
        [PrimaryKey, AutoIncrement]
        public int LocationId { get; set; }

        public string LocationName { get; set; }
    }
}
