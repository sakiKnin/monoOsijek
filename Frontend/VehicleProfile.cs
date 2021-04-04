using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Services;
using Frontend.Models;

namespace Frontend
{
	public class VehicleProfile : Profile
	{
		public VehicleProfile()
		{
			CreateMap<VehicleMakeResponse, VehicleMakeModel>();
		}
	}
}
