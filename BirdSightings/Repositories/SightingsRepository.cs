using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BirdSightings.Models;
using Dapper;

namespace BirdSightings.Repositories
{
    public class SightingsRepository
    {
        private DbConnection conn { get; set; }

        public SightingsRepository(DbConnection conn)
        {
            this.conn = conn;
        }

        public async Task<int> AddAsync(int item)
        {
            var rslt = await conn.ExecuteAsync("INSERT INTO sightings " +
                            "(species) VALUES (@species)",
                            new { species = item });
            return rslt;

        }

        public async Task<IEnumerable<Sighting>> GetAllAsync()
        {
            return await conn.QueryAsync<Sighting>("SELECT s1.seen, s1.species, s2.name FROM sightings s1 JOIN Species s2 on s1.species = s2.id");
        }
    }
}