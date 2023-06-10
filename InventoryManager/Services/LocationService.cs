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
        private DatabaseContext DB { get; set; }

        public List<LocationModel> Locations { get; set; } = new List<LocationModel>();

        public LocationModel LocationToDelete { get; set; } = null;

        public event Action OnStateChange;

        public LocationService()
        {
            if (DB != null)
            {
                return;
            }

            DB = new DatabaseContext();
            
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public void SetLocationToDelete(LocationModel location)
        {
            LocationToDelete = location;
            NotifyStateChanged();
        }

        public void ClearLocationToDelete()
        {
            LocationToDelete = null;
            NotifyStateChanged();
        }

        public async Task<List<LocationModel>> InitiateLocations()
        {
            Locations = await DB.GetAllLocations();
            NotifyStateChanged();
            return Locations;
        }

        public async Task<LocationModel> AddLocation(LocationModel location)
        {
            LocationModel newLocation = await DB.AddLocation(location);
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
            LocationModel updatedLocation = await DB.EditLocation(location);
            int index = Locations.IndexOf(location);
            Locations[index] = updatedLocation;
            NotifyStateChanged();
            return updatedLocation;
        }

        public async Task<LocationModel> DeleteLocation(LocationModel location)
        {
            int res = await DB.DeleteLocation(location);
            Locations.Remove(location);
            NotifyStateChanged();
            return location;
        }

        public async Task DeleteSelectedLocation()
        {
            int res = await DB.DeleteLocation(LocationToDelete);
            Locations.Remove(LocationToDelete);
            LocationToDelete = null;
            NotifyStateChanged();
        }
    }
}
