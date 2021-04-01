using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Frontend.Services;

namespace Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        protected readonly IApiClient _apiClient;

        public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public List<VehicleMakeResponse> Vehicles { get; set; } = new List<VehicleMakeResponse>();

        public async Task<IActionResult> OnGet()
	{
    		Vehicles = await _apiClient.GetVehicleMakeAsync();
		/*
    		if (Speaker == null)
    		{
        		return NotFound();
    		}*/

    		return Page();
	}
    }
}
