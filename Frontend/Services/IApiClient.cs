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
	
       Task<List<VehicleMakeResponse>> GetVehicleMakeAsync();
       Task<VehicleMakeResponse> GetVehicleMakeAsync(int id);
       Task<VehicleMakeModel> PostVehicleMakeAsync(VehicleMakeModel model);
       Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeModel vehicle);
       Task<VehicleMakeModel> DeleteVehicleMakeAsync(int id);

       // Abstractions for VehicleModel service	

       Task<List<VehicleModelResponse>> GetVehicleModelAsync();
       Task<VehicleModelResponse> GetVehicleModelAsync(int id);
       Task<VehicleModelModel> PostVehicleModelAsync(VehicleModelModel model);
       Task<bool> UpdateVehicleModelAsync(int id, VehicleModelModel vehicle);
       Task<VehicleModelModel> DeleteVehicleModelAsync(int id);
    }
}
