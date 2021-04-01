using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks; 
 
namespace Frontend.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<VehicleMakeResponse>> GetVehicleMakeAsync()
        {
            var response = await _httpClient.GetAsync("/api/VehicleMake");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<VehicleMakeResponse>>();
	     
        }
    }
}
