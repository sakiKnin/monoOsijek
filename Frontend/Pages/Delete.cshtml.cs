using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Frontend.Services;

using Frontend.Models;

namespace Frontend.Pages
{
    public class DeleteModel : PageModel
    {
    
        protected readonly IApiClient _apiClient;

        public DeleteModel(IApiClient apiClient)
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
