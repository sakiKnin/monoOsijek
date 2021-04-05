using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class VehicleModelModel
    {

	[Required]
	public int Id {get; set;}

	[Required]
	public int MakeId {get; set;}

	[Required]
	[StringLength(60, MinimumLength = 3)]
	public string Name {get; set;}

	[Required]
	[StringLength(60, MinimumLength = 3)]
	public string Abbrevation {get; set;}
         
    }
}
