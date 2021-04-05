using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Frontend.Services;

using Frontend.Models;

namespace Frontend.Pages.VehicleMake
{
    public class DeleteVMakeModel : PageModel
    {
    
        protected readonly IApiClient _apiClient;

        public DeleteVMakeModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> OnPost(int id)
	{
		 
		VehicleMakeModel response = await _apiClient.DeleteVehicleMakeAsync(id);
			
		ViewData["status"]=response.Id;
    		
		return Page();
	}

    }
}
