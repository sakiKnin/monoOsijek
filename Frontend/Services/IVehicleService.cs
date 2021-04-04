using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using Frontend.Models;

namespace Frontend.Services{
	public interface IVehicleService
	{
		  
    		List<VehicleMakeModel> GetPaginatedResult(List<VehicleMakeModel> vehicles, int currentPage, int pageSize = 3);
    		int GetCount(List<VehicleMakeModel> vehicles);
	}
}
