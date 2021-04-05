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

	// Services to get, set, delete and update VehicleMake items

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

	// Services to get, set, delete and update VehicleModel items
	
	public async Task<List<VehicleModelResponse>> GetVehicleModelAsync()
        {
            var response = await _httpClient.GetAsync("/api/VehicleModel");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<VehicleModelResponse>>();
	     
        }

	public async Task<VehicleModelResponse> GetVehicleModelAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleModel/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<VehicleModelResponse>();
        }
	 
	public async Task<VehicleModelModel> PostVehicleModelAsync(VehicleModelModel model)
        {
            var vehicle = new VehicleModelResponse
	    {
			Id=model.Id,
			MakeId=model.MakeId,
			Name=model.Name,
			Abbrevation=model.Abbrevation,
	    };
	
	    try
	    {
	    	var response = await _httpClient.PostAsJsonAsync($"/api/VehicleModel", vehicle);
	    	//response.EnsureSuccessStatusCode();
		if(response.IsSuccessStatusCode)
	    	{
	    		var responseText = await response.Content.ReadAsStringAsync();
	    		var data = JsonConvert.DeserializeObject<VehicleModelModel>(responseText);

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

	    return new VehicleModelModel();
	     
        }
	public async Task<bool> UpdateVehicleModelAsync(int id, VehicleModelModel vehicle)
	{
		var response = await _httpClient.PutAsJsonAsync($"/api/VehicleModel/{id}", vehicle);
		Console.WriteLine("MY response :" + response);
		//response.EnsureSuccessStatusCode();

		if (response.IsSuccessStatusCode)
		{
			return true;
		}
	      
		return false;
	}
	
	public async Task<VehicleModelModel> DeleteVehicleModelAsync(int id)
	{
		var response = await _httpClient.DeleteAsync($"/api/VehicleModel/{id}");
		Console.WriteLine("MY response :" + response);
		//response.EnsureSuccessStatusCode();
		if(response.IsSuccessStatusCode){
	      
             		var responseText = await response.Content.ReadAsStringAsync();
			var data = JsonConvert.DeserializeObject<VehicleModelModel>(responseText);
		 
			return data;
		}
		else
		{
			return new VehicleModelModel();
		}
		
	}
    }
}
