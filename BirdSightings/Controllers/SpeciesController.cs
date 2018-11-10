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
    public class SpeciesController : ControllerBase
    {
        private SpeciesRepository repo;

        public SpeciesController(SpeciesRepository repo) {
            this.repo = repo;
        }

        // GET: api/Species
        [HttpGet]
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

        // POST: api/Species
        [HttpPost]
        public void Post([FromBody] Species value) {
            repo.AddAsync(value);
        }
    }
}
