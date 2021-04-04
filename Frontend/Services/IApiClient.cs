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
       Task<VehicleMakeModel> PostVehicleMakeAsync(VehicleMakeModel model);
       Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeModel vehicle);
       Task<VehicleMakeModel> DeleteVehicleMakeAsync(int id);
    }
}
