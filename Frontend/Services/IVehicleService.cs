using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Services{
	public interface IVehicleService
	{
		List<T> GetPaginatedResult<T>(List<T> vehicles, int currentPage, int pageSize = 3);
    		int GetCount<T>(List<T> vehicles);
	}
}
