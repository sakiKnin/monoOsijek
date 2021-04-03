using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Frontend.Models;
 
namespace Frontend.Services
{
    public interface IApiClient
    {
       Task<List<VehicleMakeResponse>> GetVehicleMakeAsync();
       Task<VehicleMakeResponse> GetVehicleMakeAsync(int id);
       Task<VehicleModel> PostVehicleMakeAsync(VehicleModel model);
       Task<bool> UpdateVehicleMakeAsync(int id, VehicleModel vehicle);
       Task<VehicleModel> DeleteVehicleMakeAsync(int id);
    }
}
