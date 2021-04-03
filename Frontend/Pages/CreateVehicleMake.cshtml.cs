using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Frontend.Models;

namespace Frontend.Pages
{
    public class CreateVehicleMakeModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public CreateVehicleMakeModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
	     
        }
	
	[BindProperty]
        public VehicleModel Vehicle { get; set; }
	 
        public async Task<IActionResult> OnPost()
	{
		var vehicle = new VehicleModel{
		   	Id=Vehicle.Id,
		   	Name=Vehicle.Name,
		   	Abbrevation=Vehicle.Abbrevation,
		  	};

		var response = await _apiClient.PostVehicleMakeAsync(vehicle);
		ViewData["status"]=response.Id;
		
		return Page();
	}
    }
}
