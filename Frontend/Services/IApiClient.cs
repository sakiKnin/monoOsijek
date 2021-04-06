using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Frontend.Models;
 
namespace Frontend.Services
{
    public interface IApiClient
    {
       // Abstractions for VehicleMake service
       Task<List<T>> GetVehicleMakeAsync<T>();
       Task<T> GetVehicleMakeAsync<T>(int id);
       Task<T> PostVehicleMakeAsync<T>(VehicleMakeModel model);
       Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeModel vehicle);
       Task<T> DeleteVehicleMakeAsync<T>(int id);

       // Abstractions for VehicleModel service	
       Task<List<T>> GetVehicleModelAsync<T>();
       Task<T> GetVehicleModelAsync<T>(int id);
       Task<T> PostVehicleModelAsync<T>(VehicleModelModel model);
       Task<bool> UpdateVehicleModelAsync(int id, VehicleModelModel vehicle);
       Task<T> DeleteVehicleModelAsync<T>(int id);
    }
}
