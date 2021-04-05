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
    public class CreateModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public CreateModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
	
	[BindProperty]
        public VehicleMakeModel Vehicle { get; set; }
	 
        public async Task<IActionResult> OnPost()
	{
		if(Vehicle.Id<1 || String.IsNullOrEmpty(Vehicle.Name) || String.IsNullOrEmpty(Vehicle.Abbrevation))
					return Page();
		
		var vehicle = new VehicleMakeModel{
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
