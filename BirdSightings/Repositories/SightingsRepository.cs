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
    public class SightingsRepository
    {
        private DbConnection conn { get; set; }
        private readonly ILogger logger;

        public SightingsRepository(DbConnection conn, ILogger<SightingsRepository> logger) {
            this.conn = conn;
            this.logger = logger;
        }

        public async Task<int> AddAsync(int item) {
            var rslt = await conn.ExecuteAsync("INSERT INTO sightings " +
                            "(species) VALUES (@species)",
                            new { species = item });

            var name = await conn.QueryFirstAsync<String>("Select name FROM species WHERE id = @id", new { id = item });
            var extra = new System.Text.StringBuilder();
            extra.Append(" - kaikki havainnot: ");
            var totals = await conn.QueryAsync<Species>("SELECT * FROM species WHERE total > 0");
            foreach (Species s in totals) {
                extra.Append(s.Name + " " + s.Total.ToString() + " kpl, ");
            }
            extra.Remove(extra.Length - 2, 2);
            logger.LogInformation("Uusi havainto: {0}{1}", name, extra.ToString());

            return rslt;
        }

        public async Task<IEnumerable<Sighting>> GetAllAsync() {
            return await conn.QueryAsync<Sighting>("SELECT s1.seen, s1.species, s2.name FROM sightings s1 JOIN Species s2 on s1.species = s2.id ORDER BY s1.seen");
        }
    }
}