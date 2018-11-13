using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BirdSightings.Models;
using Dapper;
using Microsoft.Extensions.Logging;

namespace BirdSightings.Repositories
{
    public class SpeciesRepository
    {
        private DbConnection conn { get; set; }
        private readonly ILogger logger;

        public SpeciesRepository(DbConnection conn, ILogger<SpeciesRepository> logger) {
            this.conn = conn;
            this.logger = logger;
        }

        public async Task<int> AddAsync(String item) {
            var rslt = await conn.ExecuteAsync("INSERT INTO species " +
                            "(name) VALUES (@name)",
                            new { name = item });
            logger.LogInformation("Lisätty laji: {0}", item);
            return rslt;
        }

        public async Task<IEnumerable<Species>> GetAllAsync() {
            return await conn.QueryAsync<Species>("SELECT * FROM species");
        }
    }
}
