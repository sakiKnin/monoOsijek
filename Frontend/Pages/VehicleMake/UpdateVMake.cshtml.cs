using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Frontend.Models;

namespace Frontend.Pages.VehicleMake
{
    public class UpdateVMakeModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public UpdateVMakeModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

	[BindProperty]
        public VehicleMakeModel Vehicle { get; set; }

        public VehicleMakeResponse VehicleMake { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            VehicleMake = await _apiClient.GetVehicleMakeAsync<VehicleMakeResponse>(id);

            if (VehicleMake == null)
            {
                return NotFound();
            }

            return Page();
        }
	public async Task<IActionResult> OnPost(int id)
        {
	    if( Vehicle.Name.Length<3 || Vehicle.Abbrevation.Length<3 )
			 return Page();

	    var vehicle = new VehicleMakeModel{
			Id=id,
			Name=Vehicle.Name,
			Abbrevation=Vehicle.Abbrevation,
		};
	    
	    bool response = await _apiClient.UpdateVehicleMakeAsync(id, vehicle);

	    ViewData["status"] = response;
            
            return Page();
        }
    }
}
