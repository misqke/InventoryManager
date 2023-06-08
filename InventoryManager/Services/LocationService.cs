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

        public List<LocationModel> Locations { get; set; } = new List<LocationModel>();

        public LocationModel SelectedLocation { get; set; } = null;

        public event Action OnStateChange;

        public LocationService()
        {
            if (db != null)
            {
                return;
            }

            db = new DatabaseContext();
            
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public void SelectLocation(LocationModel location)
        {
            SelectedLocation = location;
            NotifyStateChanged();
        }

        public void ClearSelected()
        {
            SelectedLocation = null;
            NotifyStateChanged();
        }

        public async Task<List<LocationModel>> SetLocations()
        {
            Locations = await db.GetAllLocations();
            NotifyStateChanged();
            return Locations;
        }

        public async Task<LocationModel> AddLocation(LocationModel location)
        {
            LocationModel newLocation = await db.AddLocation(location);
            Locations.Add(newLocation);
            NotifyStateChanged();
            return newLocation;
        }

        public List<LocationModel> GetLocations()
        {
            return Locations;
        }

        public async Task<LocationModel> EditLocation(LocationModel location)
        {
            LocationModel updatedLocation = await db.EditLocation(location);
            int index = Locations.IndexOf(location);
            Locations[index] = updatedLocation;
            NotifyStateChanged();
            return updatedLocation;
        }

        public async Task<LocationModel> DeleteLocation(LocationModel location)
        {
            int res = await db.DeleteLocation(location);
            Locations.Remove(location);
            NotifyStateChanged();
            return location;
        }

        public async Task DeleteSelectedLocation()
        {
            int res = await db.DeleteLocation(SelectedLocation);
            Locations.Remove(SelectedLocation);
            SelectedLocation = null;
            NotifyStateChanged();
        }
    }
}
