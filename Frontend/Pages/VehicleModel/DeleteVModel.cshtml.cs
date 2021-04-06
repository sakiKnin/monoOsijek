using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Frontend.Services;

using Frontend.Models;

namespace Frontend.Pages.VehicleModel
{
    public class DeleteVModel : PageModel
    {
    
        protected readonly IApiClient _apiClient;

        public DeleteVModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> OnPost(int id)
	{
		 
		VehicleModelModel response = await _apiClient.DeleteVehicleModelAsync<VehicleModelModel>(id);
			
		ViewData["status"]=response.Id;
    		
		return Page();
	}

    }
}
