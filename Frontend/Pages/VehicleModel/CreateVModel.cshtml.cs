using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Frontend.Models;

namespace Frontend.Pages.VehicleModel
{
    public class CreateVModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public CreateVModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
	
	[BindProperty]
        public VehicleModelModel Vehicle { get; set; }
	 
        public async Task<IActionResult> OnPost()
	{
		if(Vehicle.Id<1 || Vehicle.MakeId<1 || (Vehicle.Name).Length<3 || (Vehicle.Abbrevation).Length<3)
					return Page();
		
		var vehicle = new VehicleModelModel{
		   	Id=Vehicle.Id,
			MakeId=Vehicle.MakeId,
		   	Name=Vehicle.Name,
		   	Abbrevation=Vehicle.Abbrevation,
		  	};

		var response = await _apiClient.PostVehicleModelAsync<VehicleModelModel>(vehicle);
		ViewData["status"]=response.Id;
		
		return Page();
	}
    }
}
