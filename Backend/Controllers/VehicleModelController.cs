using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehicleModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VehicleModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModel()
        {
            return await _context.VehicleModel.ToListAsync();
        }

        // GET: api/VehicleModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetVehicleModel(int id)
        {
            var vehicleModel = await _context.VehicleModel.FindAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return vehicleModel;
        }

        // PUT: api/VehicleModel/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.MakeId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehicleModel
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> PostVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModel.Add(vehicleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleModel", new { id = vehicleModel.MakeId }, vehicleModel);
        }

        // DELETE: api/VehicleModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteVehicleModel(int id)
        {
            var vehicleModel = await _context.VehicleModel.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            _context.VehicleModel.Remove(vehicleModel);
            await _context.SaveChangesAsync();

            return vehicleModel;
        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModel.Any(e => e.MakeId == id);
        }
    }
}
