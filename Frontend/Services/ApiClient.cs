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

        public async Task<List<T>> GetVehicleMakeAsync<T>()
        {
            var response = await _httpClient.GetAsync("/api/VehicleMake");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<T>>();
	     
        }

	public async Task<T> GetVehicleMakeAsync<T>(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleMake/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default(T);
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }
	 
	public async Task<T> PostVehicleMakeAsync<T>(VehicleMakeModel model)
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
	    		var data = JsonConvert.DeserializeObject<T>(responseText);

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

	    return default(T);
	     
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
	
	public async Task<T> DeleteVehicleMakeAsync<T>(int id)
	{
		var response = await _httpClient.DeleteAsync($"/api/VehicleMake/{id}");
		 
		//response.EnsureSuccessStatusCode();
		if(response.IsSuccessStatusCode){
	      
             		var responseText = await response.Content.ReadAsStringAsync();
			var data = JsonConvert.DeserializeObject<T>(responseText);
		 
			return data;
		}
		else
		{
			return default(T);
		}
		
	}

	// Services to get, set, delete and update VehicleModel items
	
	public async Task<List<T>> GetVehicleModelAsync<T>()
        {
            var response = await _httpClient.GetAsync("/api/VehicleModel");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<T>>();
	     
        }

	public async Task<T> GetVehicleModelAsync<T>(int id)
        {
            var response = await _httpClient.GetAsync($"/api/VehicleModel/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default(T);
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }
	 
	public async Task<T> PostVehicleModelAsync<T>(VehicleModelModel model)
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
	    		var data = JsonConvert.DeserializeObject<T>(responseText);

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

	    return default(T);
	     
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
	
	public async Task<T> DeleteVehicleModelAsync<T>(int id)
	{
		var response = await _httpClient.DeleteAsync($"/api/VehicleModel/{id}");
		Console.WriteLine("MY response :" + response);
		//response.EnsureSuccessStatusCode();
		if(response.IsSuccessStatusCode){
	      
             		var responseText = await response.Content.ReadAsStringAsync();
			var data = JsonConvert.DeserializeObject<T>(responseText);
		 
			return data;
		}
		else
		{
			return default(T);
		}
		
	}
    }
}
