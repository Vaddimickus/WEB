using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleShop.Data;
using BicycleShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BicycleShop.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase {

        private readonly AppDBContent db;

        public APIController(AppDBContent context) {
            db = context;
        }

        // GET api/bicyclesapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> GetAllBicycle() {
            return await db.Bicycle.ToListAsync();
        }

        // GET api/API/5
        [HttpGet("{id}", Name = "GetBicycle")]
        public async Task<ActionResult<Bicycle>> GetBicycle(int id) {
            Bicycle bicycle = await db.Bicycle.FirstOrDefaultAsync(x => x.id == id);
            if (bicycle == null)
                return NotFound();

            return new ObjectResult(bicycle);
        }

        // POST api/API
        [HttpPost]
        public async Task<ActionResult<Bicycle>> PostBicycle([FromBody] Bicycle bicycle) {
            if (bicycle == null)
                return BadRequest();

            db.Bicycle.Add(bicycle);
            await db.SaveChangesAsync();
            return CreatedAtRoute("GetBicycle", new { id = bicycle.id }, bicycle);
        }

        // PUT api/API/3
        [HttpPut("{id}")]
        public async Task<ActionResult<Bicycle>> PutBicycle(int id, [FromBody] Bicycle bicycle) {
            if (bicycle == null)
                return BadRequest();

            if (id != bicycle.id)
                return NotFound();

            db.Update(bicycle);
            await db.SaveChangesAsync();
            return Ok(bicycle);
        }

        // DELETE api/API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycle>> DeleteBicycle(int id) {
            Bicycle bicycle = db.Bicycle.FirstOrDefault(x => x.id == id);
            if (bicycle == null)
                return NotFound();

            db.Bicycle.Remove(bicycle);
            await db.SaveChangesAsync();
            return Ok(bicycle);
        }
    }
}
