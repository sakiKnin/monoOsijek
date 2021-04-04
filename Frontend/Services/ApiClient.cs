using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks; 
using Newtonsoft.Json;
using Frontend.Models;
 
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

	public async Task<VehicleMakeResponse> GetVehicleMakeAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleMake/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<VehicleMakeResponse>();
        }
	 
	public async Task<VehicleMakeModel> PostVehicleMakeAsync(VehicleMakeModel model)
        {
            var vehicle = new VehicleMakeResponse
	    {
			Id=model.Id,
			Name=model.Name,
			Abbrevation=model.Abbrevation,
	    };
	
	    try
	    {
	    	var response = await _httpClient.PostAsJsonAsync($"/api/VehicleMake", vehicle);
	    	//response.EnsureSuccessStatusCode();
		if(response.IsSuccessStatusCode)
	    	{
	    		var responseText = await response.Content.ReadAsStringAsync();
	    		var data = JsonConvert.DeserializeObject<VehicleMakeModel>(responseText);

	    		return data;
	    	}
	    	else
	    	{
			string msg = response.IsSuccessStatusCode.ToString();

                	throw new Exception(msg);
	 	}
	    }
	    catch(Exception e)
	    {
		 Console.WriteLine(e.ToString());
	    }

	    return new VehicleMakeModel();
	     
        }
	public async Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeModel vehicle)
	{
		var response = await _httpClient.PutAsJsonAsync($"/api/VehicleMake/{id}", vehicle);
		 
		//response.EnsureSuccessStatusCode();

		if (response.IsSuccessStatusCode)
		{
			return true;
		}
	      
		return false;
	}
	
	public async Task<VehicleMakeModel> DeleteVehicleMakeAsync(int id)
	{
		var response = await _httpClient.DeleteAsync($"/api/VehicleMake/{id}");
		 
		//response.EnsureSuccessStatusCode();
		if(response.IsSuccessStatusCode){
	      
             		var responseText = await response.Content.ReadAsStringAsync();
			var data = JsonConvert.DeserializeObject<VehicleMakeModel>(responseText);
		 
			return data;
		}
		else
		{
			return new VehicleMakeModel();
		}
		
	}
    }
}
