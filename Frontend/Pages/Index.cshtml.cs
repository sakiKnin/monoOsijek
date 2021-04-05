using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Frontend.Services;
using AutoMapper;

namespace Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        protected readonly IApiClient _apiClient;
	private readonly IMapper _mapper;

        public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient, IMapper mapper )
        {
            _logger = logger;
            _apiClient = apiClient;
	    _mapper = mapper;
        }

              
	public IActionResult OnGet()
	{
		return Page();
	}

    }
}
