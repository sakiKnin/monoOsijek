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
    public class UpdateVModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public UpdateVModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

	[BindProperty]
        public VehicleModelModel Vehicle { get; set; }

        public VehicleModelResponse VehicleModel { get; set; }

        public async Task<IActionResult> OnGet(int makeId)
        {
            VehicleModel = await _apiClient.GetVehicleModelAsync<VehicleModelResponse>(makeId);

            if (VehicleModel == null)
            {
                return NotFound();
            }

            return Page();
        }
	public async Task<IActionResult> OnPost(int id, int makeId)
        {
	    if(Vehicle.MakeId<1 || Vehicle.Name.Length<3 || Vehicle.Abbrevation.Length<3)
			 return Page();

	    var vehicle = new VehicleModelModel{
			Id=id,
			MakeId=makeId,
			Name=Vehicle.Name,
			Abbrevation=Vehicle.Abbrevation,
		};
	    
	    bool response = await _apiClient.UpdateVehicleModelAsync(makeId, vehicle);

	    ViewData["status"] = response;
            
            return Page();
        }
    }
}
