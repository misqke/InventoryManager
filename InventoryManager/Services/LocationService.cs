using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Data;

namespace InventoryManager.Services
{
    public class LocationService
    {
        private DatabaseContext db { get; set; }

        public LocationService()
        {
            if (db != null)
            {
                return;
            }

            db = new DatabaseContext();
        }

        public async Task<LocationModel> AddLocation(LocationModel location)
        {
            LocationModel newLocation = await db.AddLocation(location);
            return newLocation;
        }

        public async Task<List<LocationModel>> GetLocations()
        {
            List<LocationModel> locations = await db.GetAllLocations();
            return locations;
        }

        public async Task<LocationModel> EditLocation(LocationModel location)
        {
            LocationModel updatedLocation = await db.EditLocation(location);
            return updatedLocation;
        }

        public async Task<LocationModel> DeleteLocation(LocationModel location)
        {
            int res = await db.DeleteLocation(location);
            return location;
        }
    }
}
