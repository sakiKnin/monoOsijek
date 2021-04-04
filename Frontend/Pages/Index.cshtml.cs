using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Frontend.Services;
using Frontend.Models;
using AutoMapper;

namespace Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        protected readonly IApiClient _apiClient;
	private readonly IVehicleService _vehicleService;
	private readonly IMapper _mapper;

        public IndexModel(ILogger<IndexModel> logger, IVehicleService vehicleService, IApiClient apiClient, IMapper mapper )
        {
            _logger = logger;
            _apiClient = apiClient;
	    _vehicleService = vehicleService;
	    _mapper = mapper;
        }

        public List<VehicleMakeModel> Vehicles { get; set; } = new List<VehicleMakeModel>();
	
	public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; } = 3;
	  
	public List<VehicleMakeModel> Data {get; set;} = new List<VehicleMakeModel>();
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));        

	public async Task<IActionResult> OnGet(string sortOrder, string currentFilter, string searchString, int? currentPage)
	{

		ViewData["CurrentSort"] = sortOrder;
		ViewData["IdSortParam"] = String.IsNullOrEmpty(sortOrder) ? "idDesc" : "";		
		ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
		ViewData["AbbrevationSortParam"] = String.IsNullOrEmpty(sortOrder) ? "abbrevationDesc" : "";

		Console.WriteLine(currentFilter);

		if(searchString != null)
			currentPage=1;
		else
			searchString=currentFilter;

		if(currentPage==null)
			CurrentPage=1;
		else
			CurrentPage=(int)currentPage;
	
		ViewData["CurrentFilter"] = searchString;
		
    		var response = await _apiClient.GetVehicleMakeAsync();
		
		Vehicles = _mapper.Map<List<VehicleMakeModel>>(response);

		if (Vehicles.Count==0)
    			return Page();
	
		var vehicles = from v in Vehicles
			select v;

		if(!String.IsNullOrEmpty(searchString))
			vehicles = vehicles.Where(s => s.Name.Contains(searchString));		 
		
		switch (sortOrder)
		{
			case "idDesc":
				vehicles = vehicles.OrderByDescending(v => v.Id);
				break;
			case "nameDesc":
				vehicles = vehicles.OrderByDescending(v => v.Name);
				break;
			case "abbrevationDesc":
				vehicles = vehicles.OrderByDescending(v => v.Abbrevation);
				break;
			default:
				vehicles = vehicles.OrderBy(v => v.Id);
				break;		
		}
		 
		Data = _vehicleService.GetPaginatedResult(vehicles.ToList(), currentPage ?? 1, PageSize);
        	Count = _vehicleService.GetCount(vehicles.ToList());

    		return Page();
	}

    }
}
