using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirdSightings.Models;
using BirdSightings.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdSightings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightingsController : ControllerBase
    {
        private SightingsRepository repo;

        public SightingsController(SightingsRepository repo) {
            this.repo = repo;
        }

        // GET: api/Sightings
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> GetAll() {
            try {
                var rslt = await repo.GetAllAsync();
                if (rslt == null) {
                    return NotFound();
                }
                return new ObjectResult(rslt);
            }
            catch (Exception) {
                return BadRequest();
            }
        }

        // POST: api/Sightings
        [HttpPost]
        public async Task Post([FromBody] Species value) {
            var rslt = await repo.AddAsync(value.Id);
        }
    }
}
