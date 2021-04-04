using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using Frontend.Models;

namespace Frontend.Services
{
	public class VehicleService : IVehicleService
	{
		 
		 
		public List<VehicleMakeModel> GetPaginatedResult(List<VehicleMakeModel> vehicles, int currentPage, int pageSize = 10)
    		{

			return vehicles.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
    		}

    		public int GetCount(List<VehicleMakeModel> vehicles)
    		{

        		return vehicles.Count;
    		}


	}

}
