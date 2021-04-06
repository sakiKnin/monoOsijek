using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Services
{
	public class VehicleService : IVehicleService
	{
 
		public List<T> GetPaginatedResult<T>(List<T> vehicles, int currentPage, int pageSize = 10)
    		{
			return vehicles.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
    		}

    		public int GetCount<T>(List<T> vehicles)
    		{
        		return vehicles.Count;
    		}
	}

}
